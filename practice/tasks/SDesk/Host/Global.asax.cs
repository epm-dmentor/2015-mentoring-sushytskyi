using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Epam.Sdesk.Host
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
          //  GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(SDSK.API.WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
          //  WebApiConfig.Register();
   
        }
    }
}
