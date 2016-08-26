using System;
using System.Collections.Generic;
using ChamgeCurrency.Contracts;
using CurrencyExchangeRates.Contracts.Request;
using CurrencyExchangeRates.Contracts.Dto;

namespace CurrencyExchangeRates.Business.Operations
{
    public class GetCurrencyExchangeRatesOperation : Operation<GetCurrencyExchangeRatesRequest, IEnumerable<CurrencyExchangeRatesDto>>
    {
        public GetCurrencyExchangeRatesOperation(IContext context)
            : base(context)
        {
        }

        protected override IEnumerable<CurrencyExchangeRatesDto> OnOperate(GetCurrencyExchangeRatesRequest request)
        {
            //TODO: not implemented
            return null;
        }
    }
}
