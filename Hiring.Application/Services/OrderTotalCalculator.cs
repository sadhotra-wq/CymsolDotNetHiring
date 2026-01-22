using System;
using System.Linq;
using Hiring.Application.DTOs;
using Hiring.Application.Exceptions;
using Hiring.Application.Interfaces;
using Hiring.Domain.Entities;

namespace Hiring.Application.Services
{
    public class OrderTotalCalculator : IOrderTotalCalculator
    {
        private const decimal DiscountRate = 0.10m;
        private const decimal TaxRate = 0.18m;
        private const decimal DiscountThreshold = 1000.00m;

        public OrderTotalsDto CalculateTotals(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            if (order.Lines == null || !order.Lines.Any())
            {
                throw new InvalidOrderException("Order must contain at least one line.");
            }

            foreach (var line in order.Lines)
            {
                ValidateLine(line);
            }

            var subtotal = order.Lines.Sum(line => line.UnitPrice * line.Quantity);
            var discountRate = subtotal > DiscountThreshold ? DiscountRate : 0m;
            var discountAmount = Math.Round(subtotal * discountRate, 2, MidpointRounding.AwayFromZero);
            var taxBase = subtotal - discountAmount;
            var taxAmount = Math.Round(taxBase * TaxRate, 2, MidpointRounding.AwayFromZero);
            var total = (subtotal - discountAmount) + taxAmount;

            return new OrderTotalsDto
            {
                Subtotal = subtotal,
                DiscountAmount = discountAmount,
                TaxAmount = taxAmount,
                Total = total
            };
        }

        private static void ValidateLine(OrderLine line)
        {
            if (line == null)
            {
                throw new InvalidOrderLineException("Order line cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(line.ProductName))
            {
                throw new InvalidOrderLineException("Product name is required.");
            }

            if (line.ProductName.Length > 100)
            {
                throw new InvalidOrderLineException("Product name cannot exceed 100 characters.");
            }

            if (line.UnitPrice <= 0)
            {
                throw new InvalidOrderLineException("Unit price must be greater than zero.");
            }

            if (line.Quantity <= 0)
            {
                throw new InvalidOrderLineException("Quantity must be greater than zero.");
            }
        }
    }
}
