using System.Collections.Generic;
using OpenQA.Selenium;
using VKMusicRemote.DataTransferObjects;
using VKMusicRemote.Selenium.Login;

namespace VKMusicRemote.Selenium
{
    public interface IVkClient
    {
        bool IsLogged { get; }

        LoginInformation Login(string login, string password);
        bool Logout();
        bool TwoFactorAuthentication(string code);

        ICollection<Song> GetUserMusic();
        bool PlaySong(Song song);
        ICollection<Song> SearchSongs(string criterea, bool searchOnlyInUserSongs = false);
        bool SwitchPlayback();
    }
}