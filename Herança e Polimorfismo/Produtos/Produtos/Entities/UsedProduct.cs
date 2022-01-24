using System.Text;
using System.Globalization;

namespace Produtos.Entities
{
    internal class UsedProduct : Product
    {
        public DateOnly ManufactureDate { get; set; }

        public UsedProduct()
        {

        }

        public UsedProduct(string name, double price, DateOnly manufactureDate) : base(name, price)
        {
            ManufactureDate = manufactureDate;
        }
        public override string priceTag()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name + " (Used) ");
            sb.Append(" $ " + Price.ToString("F2", CultureInfo.InvariantCulture));
            sb.Append(" (Manufacture date: " + ManufactureDate.ToString("dd/MM/yyyy")+")");

            return sb.ToString();
        }
    }
}
