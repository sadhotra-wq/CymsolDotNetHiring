namespace Hiring.Application.DTOs
{
    public class OrderTotalsDto
    {
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
    }
}
