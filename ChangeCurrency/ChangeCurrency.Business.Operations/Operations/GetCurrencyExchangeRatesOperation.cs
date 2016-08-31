using System.Collections.Generic;
using System.Linq;
using ChamgeCurrency.Contracts;
using ChangeCurrency.Business.Operations.ExchangeRatesService;
using ChangeCurrency.Business.Operations.Mappers;
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
            var result = new List<CurrencyExchangeRatesDto>();
            using (var service = new ExchangeRatesSoapClient())
            {
                var serviceResult = service.getExchangeRatesByDate(request.Date).To<ExchangeRates>();
                result = serviceResult.ToCurrencyExchangeRatesDtoList().ToList();

            }
            return result;
        }
    }
}
