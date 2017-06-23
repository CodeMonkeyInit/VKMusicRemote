using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using VKMusicRemote.Selenium;

namespace VKMusicRemote.CastleWindsor
{
    public class ServicesWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IVkClient>()
                    .ImplementedBy<VkClient>()
            );
        }
    }
}