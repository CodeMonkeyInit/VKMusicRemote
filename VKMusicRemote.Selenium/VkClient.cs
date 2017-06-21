using Castle.Windsor;
using OpenQA.Selenium;
using VKMusicRemote.Selenium.CastleInstaller;
using VKMusicRemote.Selenium.Login;

namespace VKMusicRemote.Selenium
{
    public class VkClient : IVkClient
    {
        private readonly IWindsorContainer _container;
        private readonly IWebDriver _browserDriver;
        private readonly IVkLoginManager _vkLoginManager;

        public const string VkLoginPage = @"https://vk.com/";

        public bool IsLogged => _vkLoginManager.IsLogged(_browserDriver);

        public bool Logout()
        {
            return _vkLoginManager.Logout(_browserDriver);
        }

        public LoginInformation Login(string login, string password)
        {
            if (IsLogged)
            {
                Logout();
            }

            _browserDriver.Url = VkLoginPage;

            return _vkLoginManager.Login(login, password, _browserDriver);
        }

        public bool TwoFactorAuthentication(string code)
        {
            return _vkLoginManager.TwoFactorAuthentication(code, _browserDriver);
        }

        public VkClient()
        {
            _container = new WindsorContainer().Install(new VkRemoteCastleInstaller());
            _browserDriver = _container.Resolve<IWebDriver>();
            _vkLoginManager = _container.Resolve<IVkLoginManager>();
        }
    }
}