using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Hiring.Application.Interfaces;
using Hiring.Domain.Entities;

namespace Hiring.Persistence.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly ConcurrentDictionary<Guid, Order> _orders = new ConcurrentDictionary<Guid, Order>();

        public void Add(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _orders[order.Id] = order;
        }

        public Order Get(Guid id)
        {
            _orders.TryGetValue(id, out var order);
            return order;
        }

        public IReadOnlyCollection<Order> GetAll()
        {
            return _orders.Values.ToList().AsReadOnly();
        }
    }
}
