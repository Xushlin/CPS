using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace HtmlAgilityPackTool.WCFService.IoC
{
    public class Container
    {
        private static readonly object _syncRoot = new object();
        private static IUnityContainer _instance;


        public static IUnityContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new UnityContainer();

                            UnityConfigurationSection section = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");

                            section.Configure(_instance);
                            
                        }
                    }
                }
                return _instance;
            }
        }

    }
}