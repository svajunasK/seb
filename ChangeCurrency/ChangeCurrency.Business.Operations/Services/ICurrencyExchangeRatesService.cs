using System.Collections.Generic;
using ChamgeCurrency.Contracts;
using ChangeCurrency.Contracts;
using CurrencyExchangeRates.Contracts.Dto;
using CurrencyExchangeRates.Contracts.Request;
using CurrencyExchangeRates.Business.Operations;

namespace ChangeCurrency.Business.Operations.Services
{
    public class CurrencyExchangeRatesService : ServiceBase, ICurrencyExchangeRatesService
    {
        public CurrencyExchangeRatesService(IOperationFactory operationFactory) 
            : base(operationFactory)
        {
        }

        public IEnumerable<CurrencyExchangeRatesDto> GetCurrencyExchangeRates(GetCurrencyExchangeRatesRequest request)
        {
            var operation = CreateOperation<GetCurrencyExchangeRatesOperation>();
            return operation.Operate(request);
        }
    }
}
