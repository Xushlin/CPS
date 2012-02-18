using System;
using Microsoft.Practices.Unity;

namespace HtmlAgilityPackTool.WCFService.IoC.Unity
{
    public class UnityServiceHost : System.ServiceModel.Web.WebServiceHost
    {
        IUnityContainer _container;

        public UnityServiceHost(
            Type serviceType,
            IUnityContainer container,
            params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            _container = container;
        }

        protected override void OnOpening()
        {
            new UnityServiceBehavior(_container).AddToHost(this);

            base.OnOpening();
        }
    }

}