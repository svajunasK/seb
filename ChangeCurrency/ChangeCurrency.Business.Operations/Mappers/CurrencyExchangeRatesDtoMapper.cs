using CurrencyExchangeRates.Contracts.Dto;
using System.Collections.Generic;

namespace ChangeCurrency.Business.Operations.Mappers
{
    public static class CurrencyExchangeRatesDtoMapper
    {
        public static IEnumerable<CurrencyExchangeRatesDto> ToCurrencyExchangeRatesDtoList(this ExchangeRates source)
        {
            var resultList = new List<CurrencyExchangeRatesDto>();

            if (source == null || source.item == null || source.item.Length == 0)
                return resultList;

            foreach (var exchangeRatesItem in source.item)
            {
                resultList.Add(exchangeRatesItem.ToCurrencyExchangeRatesDto());
            }

            return resultList;
        }

        public static CurrencyExchangeRatesDto ToCurrencyExchangeRatesDto(this ExchangeRatesItem source)
        {
            if (source == null)
                return null;
            
            return new CurrencyExchangeRatesDto
            {
                Currency = source.currency,
                Date = source.date,
                Quantity = source.quantity,
                Rate = source.rate,
                Unit = source.unit
            };
        }
    }
}
