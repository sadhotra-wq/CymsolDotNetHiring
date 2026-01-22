using Hiring.Application.Interfaces;
using Hiring.Application.Services;
using Hiring.Infrastructure.Services;
using Hiring.Persistence.Repositories;

namespace Hiring.Web
{
    public static class DependencyConfig
    {
        public static void Register()
        {
            ServiceLocator.OrderTotalCalculator = new OrderTotalCalculator();
            ServiceLocator.Clock = new SystemClock();
            ServiceLocator.OrderRepository = new InMemoryOrderRepository();
        }
    }

    public static class ServiceLocator
    {
        public static IOrderTotalCalculator OrderTotalCalculator { get; set; }
        public static IClock Clock { get; set; }
        public static IOrderRepository OrderRepository { get; set; }
    }
}
