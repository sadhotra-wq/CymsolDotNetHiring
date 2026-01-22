using System.Collections.Generic;
using System.Web.Mvc;
using Hiring.Application.Interfaces;
using Hiring.Domain.Entities;

namespace Hiring.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderTotalCalculator _calculator;

        public OrdersController()
            : this(ServiceLocator.OrderTotalCalculator)
        {
        }

        public OrdersController(IOrderTotalCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public JsonResult Sample()
        {
            var order = new Order(lines: new List<OrderLine>
            {
                new OrderLine("Laptop", 899.99m, 1),
                new OrderLine("Monitor", 249.50m, 2),
                new OrderLine("Mouse", 25.00m, 3)
            });

            var totals = _calculator.CalculateTotals(order);

            return Json(totals, JsonRequestBehavior.AllowGet);
        }
    }
}
