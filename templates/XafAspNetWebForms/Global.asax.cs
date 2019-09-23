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
            WebApplication.SetInstance(Session, new Application());
            WebApplication.Instance.SwitchToNewStyle();
            WebApplication.Instance.Modules.Add(new SystemAspNetModule());
            WebApplication.Instance.Modules.Add(new Module());
            WebApplication.Instance.Setup();
            WebApplication.Instance.Start();
        }
    }

    public class Module : ModuleBase
    {
        protected override System.Collections.Generic.IEnumerable<Type> GetDeclaredExportedTypes() => new[] { typeof(Person) };
        
        [DevExpress.Persistent.Base.NavigationItem("Default")]
        public class Person : DevExpress.Xpo.XPObject
        {
            public string Name { get; set; }
        }
    }
}