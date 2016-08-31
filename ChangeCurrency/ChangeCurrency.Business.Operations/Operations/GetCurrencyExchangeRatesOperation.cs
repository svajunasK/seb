using System.Collections.Generic;
using System.Linq;
using ChamgeCurrency.Contracts;
using ChangeCurrency.Business.Operations.ExchangeRatesService;
using ChangeCurrency.Business.Operations.Mappers;
using CurrencyExchangeRates.Contracts.Request;
using CurrencyExchangeRates.Contracts.Dto;
using System.Data.SqlClient;

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
            return OrderList(result, request.SortBy, request.SortOrder);
        }

        private IEnumerable<CurrencyExchangeRatesDto> OrderList(List<CurrencyExchangeRatesDto> listToSort, SortField sortBy, SortOrder sortOrder)
        {
            if (listToSort == null || listToSort.Count == 0)
                return listToSort;

            switch (sortBy)
            {
                case SortField.Date:
                default:
                    if (sortOrder == SortOrder.Ascending)
                        return listToSort.OrderBy(_=>_.Date);
                    else
                        return listToSort.OrderByDescending(_=>_.Date);
            }
        }
    }
}
