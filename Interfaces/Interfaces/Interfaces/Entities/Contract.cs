namespace Interfaces
{
    internal class Contract
    {
        public int Number { get; set; } //Numero do contrato
        public DateTime Date { get; set; } //Data de início do contrato
        public double TotalValue { get; set; } // Valor total do contrato sem juros
        public Installment Installment { get; set; }// Valor das prestações

        public Contract(int number, DateTime date, double totalValue, Installment installment)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
            Installment = installment;
        }
    }
}