using Hiring.Application.DTOs;
using Hiring.Domain.Entities;

namespace Hiring.Application.Interfaces
{
    public interface IOrderTotalCalculator
    {
        OrderTotalsDto CalculateTotals(Order order);
    }
}
