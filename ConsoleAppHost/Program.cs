using System;
using System.ServiceModel;
using VKMusicRemote.Services;

namespace ConsoleAppHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost loginServiceHost = new ServiceHost(typeof(LoginService));
            ServiceHost musicServiceHost = new ServiceHost(typeof(MusicService));
            
            loginServiceHost.Open();
            musicServiceHost.Open();

            Console.WriteLine("Hosts open");
            
            Console.ReadKey();

            loginServiceHost.Close();
            musicServiceHost.Close();
        }
    }
}