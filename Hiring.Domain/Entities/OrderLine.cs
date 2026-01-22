namespace Hiring.Domain.Entities
{
    public class OrderLine
    {
        public OrderLine()
        {
        }

        public OrderLine(string productName, decimal unitPrice, int quantity)
        {
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
