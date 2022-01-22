using System.Globalization;
namespace CursoCSharp.Entities
{
    internal class OrderItem
    {
        public int quantity { get; set; }
        public double price { get; set; }
        public Product product { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int quantity, double price, Product product)
        {
            this.product = product;
            this.quantity = quantity;
            this.price = price;
        }

        public double subTotal()
        {
            return quantity * price;
        }
        public override string ToString()
        {
            return product.name
                + ", $"
                + price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantity: "
                + quantity
                + ", Subtotal: $"
                + subTotal().ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}
