using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AppDataTools
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();
            HttpException httpException = ex as HttpException;
            int codeError = httpException.GetHttpCode();
            RouteData routeData = new RouteData();
            if (codeError.Equals(400) || codeError.Equals(401) || codeError.Equals(404))
            {
                Response.RedirectToRoute(new
                {
                    controller = "Autenticacion",
                    action = "Login"
                });
            }
            Context.ClearError();
        }
    }
}
