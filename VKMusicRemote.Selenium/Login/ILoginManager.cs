using OpenQA.Selenium;

namespace VKMusicRemote.Selenium.Login
{
    public interface IVkLoginManager
    {
        bool IsLogged(IWebDriver browser);
        LoginInformation Login(string login, string password, IWebDriver browser);
        bool TwoFactorAuthentication(string authenticationCode, IWebDriver browser);
        bool Logout(IWebDriver browser);
    }
}