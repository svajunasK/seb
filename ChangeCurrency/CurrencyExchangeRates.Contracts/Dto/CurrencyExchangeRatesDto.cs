namespace CurrencyExchangeRates.Contracts.Dto
{
    public class CurrencyExchangeRatesDto
    {
        public string Date { get; set; }

        public string Currency { get; set; }

        public ushort Quantity { get; set; }

        public decimal Rate { get; set; }

        public string Unit { get; set; }
    }
}