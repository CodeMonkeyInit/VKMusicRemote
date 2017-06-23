using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VKMusicRemote.Selenium.Cookies;
using VKMusicRemote.Selenium.Login;

namespace VKMusicRemote.Selenium.CastleInstaller
{
    public class VkRemoteCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IVkLoginManager>()
                    .ImplementedBy<VkLoginManager>()
            );

            container.Register(
                Component
                    .For<IWebDriver>()
                    .ImplementedBy<ChromeDriver>()
            );

            container.Register(
                Component
                    .For<IVkRemoteMusic>()
                    .ImplementedBy<VkRemoteMusic>()
            );

            container.Register(
                Component
                    .For<ICookieManager>()
                    .ImplementedBy<CookieManager>()
            );
        }
    }
}