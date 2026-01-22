using System;

namespace Hiring.Application.Interfaces
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
}
