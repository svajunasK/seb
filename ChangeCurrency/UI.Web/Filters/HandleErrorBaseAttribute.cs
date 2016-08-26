using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Filters
{
    public class HandleErrorBaseAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.IsChildAction ||
                filterContext.ExceptionHandled ||
                !filterContext.HttpContext.IsCustomErrorEnabled)
                return;

            var statusCode = (int)HttpStatusCode.InternalServerError;

            var exception = filterContext.Exception as HttpException;
            if (exception != null)
            {
                statusCode = exception.GetHttpCode();
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = statusCode;
        }

    }
}