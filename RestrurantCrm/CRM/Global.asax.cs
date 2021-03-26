using Repo.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            //Response.Clear();
            (new HelperFactory()).LogtoSQL2(ex, "CRM=>global", "");
            Server.ClearError();
            Response.Redirect("/ErrorsWeb/Errors");
        }
    }
}
