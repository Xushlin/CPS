using System;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace HtmlAgilityPackTool.WCFService.IoC.Unity
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        public Type ServiceType { set; get; }
        private IUnityContainer _container;

        public UnityInstanceProvider(IUnityContainer container)
        {
            _container = container;
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return _container.Resolve(ServiceType);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }

    }

}