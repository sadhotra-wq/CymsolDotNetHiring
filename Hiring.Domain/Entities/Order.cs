using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hiring.Domain.Entities
{
    public class Order
    {
        private readonly List<OrderLine> _lines;

        public Order()
        {
            Id = Guid.NewGuid();
            _lines = new List<OrderLine>();
        }

        public Order(Guid id, IEnumerable<OrderLine> lines)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            _lines = lines == null ? new List<OrderLine>() : new List<OrderLine>(lines);
        }

        public Guid Id { get; set; }

        public IReadOnlyCollection<OrderLine> Lines => new ReadOnlyCollection<OrderLine>(_lines);

        public void AddLine(OrderLine line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            _lines.Add(line);
        }
    }
}
