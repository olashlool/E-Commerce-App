namespace Cosmetic_Store.Models
{
    public class OrderItems
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        // Navigational Properties
        public Order Order { get; set; }

        public Product Product { get; set; }

    }
}
