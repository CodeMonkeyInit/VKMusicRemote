using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKMusicRemote.ConsoleTest.LoginService;

namespace VKMusicRemote.ConsoleTest
{
    class Program
    {
        private static void Login()
        {
            Console.Write("Login: ");

            string login = Console.ReadLine()?.Trim();

            Console.Write("Password: ");

            string password = Console.ReadLine()?.Trim();

            Console.Clear();

            var vkClient = new LoginServiceClient();

            LoginInformation loginInformation = vkClient.Login(login, password);

            if (loginInformation.Success)
            {
                Console.WriteLine("Success");
            }

            if (loginInformation.ErrorType == LoginError.TwoFactorAuthenticationRequired)
            {
                Console.WriteLine("Write to factor code");

                string code = Console.ReadLine();

                bool success = vkClient.TwoFactorAuthentication(code);

                if (success)
                {
                    Console.WriteLine("Атлична");
                }
            }
        }

        static void Main(string[] args)
        {
            Login();
        }
    }
}
