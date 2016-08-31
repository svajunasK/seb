using System.Data.SqlClient;

namespace CurrencyExchangeRates.Contracts.Request
{
    public class GetCurrencyExchangeRatesRequest
    {
        public string Date { get; set; }
        public SortField SortBy { get; set; }
        public SortOrder SortOrder { get; set; }
    }
}
