using System.ServiceModel.Description;
using Microsoft.Practices.Unity;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Collections.ObjectModel;

namespace HtmlAgilityPackTool.WCFService.IoC.Unity
{
    public class UnityServiceBehavior : IServiceBehavior
    {
        public UnityInstanceProvider InstanceProvider
        { get; set; }

        private System.ServiceModel.ServiceHost serviceHost = null;

        public UnityServiceBehavior(IUnityContainer unity)
        {
            InstanceProvider = new UnityInstanceProvider(unity);
        }

        public void ApplyDispatchBehavior(
          ServiceDescription serviceDescription,
          ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase cdb
                 in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher cd = cdb as ChannelDispatcher;

                if (cd != null)
                {
                    foreach (EndpointDispatcher ed
                                    in cd.Endpoints)
                    {
                        InstanceProvider.ServiceType
                             = serviceDescription.ServiceType;
                        ed.DispatchRuntime.InstanceProvider
                             = InstanceProvider;

                    }
                }
            }
        }

        public void AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        { 
        }

        public void Validate(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase) { }

        public void AddToHost(System.ServiceModel.ServiceHost host)
        {
            // only add to host once
            if (serviceHost != null) return;            
            host.Description.Behaviors.Add(this);
            
            serviceHost = host;
        }
    }


}