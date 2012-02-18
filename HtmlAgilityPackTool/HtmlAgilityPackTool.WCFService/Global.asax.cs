using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace HtmlAgilityPackTool.WCFService
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            RouteTable.Routes.Add(new ServiceRoute("MokoService", new IoC.Unity.UnityServiceHostFactory(), typeof(MokoService)));
        }
    }
}