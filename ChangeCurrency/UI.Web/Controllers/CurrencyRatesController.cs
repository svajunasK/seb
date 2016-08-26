using System;
using System.Collections.Generic;
using System.Web.Http;

namespace UI.Web.Controllers
{
    public class CurrencyRatesController : BaseApiController
    {
        // GET: api/CurrencyRates
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CurrencyRates/5
        public string Get(DateTime date)
        {
            return "value";
        }

        // POST: api/CurrencyRates
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CurrencyRates/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CurrencyRates/5
        public void Delete(int id)
        {
        }
    }
}
