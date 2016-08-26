using System.Web.Mvc;
using UI.Web.Filters;

namespace UI.Web.App_Start
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogErrorAttribute());
            filters.Add(new HandleErrorBaseAttribute());
        }
    }
}