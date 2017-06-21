using VKMusicRemote.Selenium.Login;

namespace VKMusicRemote.Selenium
{
    public interface IVkClient
    {
        bool IsLogged { get; }

        LoginInformation Login(string login, string password);
        bool Logout();
        bool TwoFactorAuthentication(string code);
    }
}