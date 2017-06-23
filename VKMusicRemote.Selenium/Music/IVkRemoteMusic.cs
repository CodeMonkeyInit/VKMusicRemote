using System.Collections.Generic;
using OpenQA.Selenium;
using VKMusicRemote.DataTransferObjects;

namespace VKMusicRemote.Selenium
{
    public interface IVkRemoteMusic
    {
        ICollection<Song> GetUserMusic(IWebDriver browser);
        void PlaySong(IWebDriver browser, Song song);
        ICollection<Song> SearchSongs(IWebDriver browser, string criterea, bool searchOnlyInUserSongs = false);
        void SwitchPlayback(IWebDriver browser);
    }
}