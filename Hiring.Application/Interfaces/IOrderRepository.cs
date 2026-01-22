using System;
using System.Collections.Generic;
using Hiring.Domain.Entities;

namespace Hiring.Application.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order Get(Guid id);
        IReadOnlyCollection<Order> GetAll();
    }
}
