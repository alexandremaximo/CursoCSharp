using System.Text;
using System.Globalization;

namespace Produtos.Entities
{
    internal class ImportedProduct : Product
    {
        public double CustomsFee { get; set; }

        public ImportedProduct()
        {
        }

        public ImportedProduct(string name, double price, double customsFee) : base(name, price)
        {
            CustomsFee = customsFee;
        }
        public override string priceTag()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" $ " + totalPrice().ToString("F2", CultureInfo.InvariantCulture));
            sb.Append(" (Customs fee: $ " + CustomsFee.ToString("F2",CultureInfo.InvariantCulture) + ")");

            return sb.ToString();
        }
        public double totalPrice()
        {
            Price += CustomsFee;
            return Price;
        }
    }
}
