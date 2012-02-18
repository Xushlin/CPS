using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace HtmlAgilityPackTool.Service.Common.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                .Where(x => x.Name.EndsWith("Service"))
                .WithServiceDefaultInterfaces());
        }
    }


}