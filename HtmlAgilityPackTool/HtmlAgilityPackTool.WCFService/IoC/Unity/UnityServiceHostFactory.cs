using System;
using System.ServiceModel.Activation;

namespace HtmlAgilityPackTool.WCFService.IoC.Unity
{
    public class UnityServiceHostFactory : WebServiceHostFactory
    {
        protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            UnityServiceHost host = new UnityServiceHost(serviceType, Container.Instance, baseAddresses);        

            return host;
        }
    }
}