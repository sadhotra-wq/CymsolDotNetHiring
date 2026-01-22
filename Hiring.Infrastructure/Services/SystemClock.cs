using System;
using Hiring.Application.Interfaces;

namespace Hiring.Infrastructure.Services
{
    public class SystemClock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
