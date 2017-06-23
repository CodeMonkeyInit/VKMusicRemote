using System;
using System.Collections.Generic;
using VKMusicRemote.ConsoleTest.LoginService;
using VKMusicRemote.ConsoleTest.MusicService;

namespace VKMusicRemote.ConsoleTest
{
    class Program
    {
        private static void Login()
        {
            using (var vkClient = new LoginServiceClient())
            {
                if (vkClient.IsLogged())
                {
                    return;
                }

                Console.Write("Login: ");

                string login = Console.ReadLine()?.Trim();

                Console.Write("Password: ");

                string password = Console.ReadLine()?.Trim();

                Console.Clear();

                LoginInformation loginInformation = vkClient.Login(login, password);

                if (loginInformation.Success)
                {
                    Console.WriteLine("Success");
                }

                if (loginInformation.ErrorType == LoginError.TwoFactorAuthenticationRequired)
                {
                    bool success = false;

                    while (!success)
                    {
                        Console.WriteLine("Write two factor code");

                        string code = Console.ReadLine();

                        success = vkClient.TwoFactorAuthentication(code);
                    }

                    Console.WriteLine("Атлична");
                }
            }
        }

        public static void PrintAllMusic(ICollection<Song> songs)
        {
            foreach (Song song in songs)
            {
                Console.WriteLine($"{song.Id}. {song.Artist} - {song.Name} {song.Length}");
            }
        }

        public static void SearchMusic()
        {
            using (var musicServiceClient = new MusicServiceClient())
            {
                Console.WriteLine("Введите запрос: ");

                string critera = Console.ReadLine();

                Song[] allMusic = musicServiceClient.SearchSongs(critera, false);

                PrintAllMusic(allMusic);

                Console.WriteLine("Выберите песню");

                int userInput = int.Parse(Console.ReadLine());

                musicServiceClient.PlaySong(new Song {Id = userInput});

                Console.ReadKey();

                musicServiceClient.SwitchPlayback();
            }
        }

        static void Main(string[] args)
        {
            Login();
            SearchMusic();
        }
    }
}