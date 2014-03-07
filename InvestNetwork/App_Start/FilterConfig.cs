using InvestNetwork.Ninject;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}