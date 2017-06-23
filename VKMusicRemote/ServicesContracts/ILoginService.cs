using System.ServiceModel;
using VKMusicRemote.DataTransferObjects;
using VKMusicRemote.Selenium.Login;

namespace VKMusicRemote.ServicesContracts
{
    [ServiceContract]
	public interface ILoginService
    {
        [OperationContract]
        bool IsLogged();

        [OperationContract]
        LoginInformation Login(string login, string password);

        [OperationContract]
        bool Logout();

        [OperationContract]
        bool TwoFactorAuthentication(string code);
    }
}
