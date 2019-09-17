using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.SystemModule;
using System;
using System.Web;
using System.Web.Routing;

namespace XafAspNetWebForms
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e) => RouteTable.Routes.RegisterXafRoutes();

        protected void Session_End(object sender, EventArgs e) => WebApplication.DisposeInstance(Session);

        protected void Session_Start(object sender, EventArgs e)
        {
            WebApplication.SetInstance(Session, new WebApplication());
            WebApplication.Instance.SwitchToNewStyle();
            WebApplication.Instance.CreateCustomObjectSpaceProvider += (s, args)
                => args.ObjectSpaceProvider = new NonPersistentObjectSpaceProvider();
            WebApplication.Instance.Modules.Add(new SystemAspNetModule());
            WebApplication.Instance.Setup();
            WebApplication.Instance.Start();
        }
    }
}
