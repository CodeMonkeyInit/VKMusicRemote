using System;
using System.ServiceModel;
using VKMusicRemote.Services;

namespace ConsoleAppHost
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(LoginService));
            
            serviceHost.Open();

            Console.WriteLine("Host open");
            
            Console.ReadKey();

            serviceHost.Close();
        }
    }
}