namespace TokenManager
{
    public interface ILoginManager
    {
        bool IsLogged();
        LoginInformation Login(string login, string password);
    }
}