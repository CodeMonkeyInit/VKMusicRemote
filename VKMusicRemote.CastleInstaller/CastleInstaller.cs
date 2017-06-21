using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace VKMusicRemote.CastleInstaller
{
    public class CastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(
            //    Component
            //        .For<ILoginManager>()
            //        .ImplementedBy<LoginManager>()
            //);

            container.Register(
                Component.For<ILoginManager>()
            )
        }
    }
}