using System.Collections.Generic;
using CurrencyExchangeRates.Contracts.Request;
using CurrencyExchangeRates.Contracts.Dto;

namespace ChangeCurrency.Contracts
{
    public interface ICurrencyExchangeRatesService
    {
        IEnumerable<CurrencyExchangeRatesDto> GetCurrencyExchangeRates(GetCurrencyExchangeRatesRequest request);
    }
}
