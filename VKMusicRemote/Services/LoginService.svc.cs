using Castle.Windsor;
using VKMusicRemote.CastleWindsor;
using VKMusicRemote.DataTransferObjects;
using VKMusicRemote.Selenium;
using VKMusicRemote.Selenium.Login;
using VKMusicRemote.ServicesContracts;

namespace VKMusicRemote.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        private readonly IWindsorContainer _container = ServicesContainer.Container;

        private readonly IVkClient _vkClient;
        
        public LoginService()
        {
            _vkClient = _container.Resolve<IVkClient>();
        }

        public bool IsLogged()
        {
            return _vkClient.IsLogged;
        }

        public LoginInformation Login(string login, string password)
        {
            return _vkClient.Login(login, password);
        }

        public bool Logout()
        {
            return _vkClient.Logout();
        }

        public bool TwoFactorAuthentication(string code)
        {
            return _vkClient.TwoFactorAuthentication(code);
        }
    }
}
