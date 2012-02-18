using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using HtmlAgilityPackTool.Service;

namespace HtmlAgilityPack.Tool.Web.Bootstrapping
{
    public static class Bootstrapper
    {
        public static IWindsorContainer ConfigureContainer<TStartController>()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IWindsorContainer>().Instance(container));
            container.Install(FromAssembly.This());
            container.Install(FromAssembly.Containing<IShowService>());
            container.Install(FromAssembly.Named("HtmlAgilityPackTool.Data"));

            var controllerFactory = container.Resolve<IControllerFactory>();
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            return container;
        }
    }
}