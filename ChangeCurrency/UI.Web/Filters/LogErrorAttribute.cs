using ChamgeCurrency.Contracts;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Filters
{
    public class LogErrorAttribute : HandleErrorAttribute
    {
        private readonly ILogger _logger = DependencyResolver.Current.GetService<ILogger>();

        public override void OnException(ExceptionContext filterContext)
        {
            var ctx = filterContext.HttpContext.ApplicationInstance.Context;
            _logger.Error(filterContext.Exception);
            
            base.OnException(filterContext);
        }

        private static void WriteUri(StringBuilder buffer, HttpRequest request)
        {
            buffer.AppendLine("Uri: " + request.Url);
        }

        private static void WriteContent(StringBuilder buffer, HttpRequest request)
        {
            WriteCollection(buffer, request.Headers, "Headers");
            WriteCollection(buffer, request.QueryString, "QueryString");
            WriteCollection(buffer, request.Form, "Form");
        }

        private static void WriteCollection(StringBuilder buffer, System.Collections.Specialized.NameValueCollection collection, string collectionName)
        {
            if (collection.Count == 0)
            {
                return;
            }

            buffer.AppendLine(string.Concat(collectionName, ": "));
            foreach (var key in collection.AllKeys.Where(k => k != null))
            {
                buffer.AppendFormat("{0}: {1}\r\n", key, collection[key]);
            }
        }
    }
}