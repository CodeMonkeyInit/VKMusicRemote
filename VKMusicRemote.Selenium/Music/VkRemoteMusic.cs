using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using VKMusicRemote.DataTransferObjects;

namespace VKMusicRemote.Selenium
{
    public class VkRemoteMusic : IVkRemoteMusic
    {
        private const string SongRowClass = "audio_row__inner";

        private const string GlobalSearchSongClass = "_audio_section_global_search__audios_list audio_w_covers";

        private const string PlaybackButtonClass = "audio_page_player_play";

        private const string UserAudioSearchContainerClass = "_audio_section_search__local_audios_list";

        private const string AudioSearchId = "audio_search";

        public const string VkMusicUrl = @"https://vk.com/audio";


        private ICollection<Song> ParseSongsList(ReadOnlyCollection<IWebElement> songsWebElements)
        {
            const int songLengthPart = 0;
            const int songArtistPart = 1;
            const int songNamePart = 2;
            
            var songs = new List<Song>();
            int currentId = 0;

            foreach (IWebElement songElement in songsWebElements)
            {

                string[] songDetails = songElement.Text.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                
                Song song = new Song
                {
                    Id = currentId,

                    Name = songDetails[songNamePart],

                    Length = songDetails[songLengthPart],

                    Artist = songDetails[songArtistPart]
                };

                songs.Add(song);
                
                currentId++;
            }

            return songs;
        }

        public ICollection<Song> GetUserMusic(IWebDriver browser)
        {
            browser.Url = VkMusicUrl;

            ReadOnlyCollection<IWebElement> songs = browser.FindElements(
                By.ClassName(SongRowClass)
            );

            return ParseSongsList(songs);
        }

        public void PlaySong(IWebDriver browser, Song song)
        {
            if (song.Id < 0)
            {
                throw new ArgumentException(nameof(song.Id));
            }

            ReadOnlyCollection<IWebElement> songsElements = browser.FindElements(
                By.ClassName(SongRowClass)
            );

            songsElements[song.Id].Click();
        }

        public ICollection<Song> SearchSongs(IWebDriver browser, string criterea, bool searchOnlyInUserSongs = false)
        {
            if (string.IsNullOrWhiteSpace(criterea))
            {
                throw new ArgumentException(nameof(criterea));
            }

            browser.Url = VkMusicUrl;

            ReadOnlyCollection<IWebElement> songs;
            
            IWebElement songSearchField = browser.FindElement(
                By.Id(AudioSearchId)
            );

            songSearchField.SendKeys(criterea + Keys.Enter);

            WebDriverWait waitForElement = new WebDriverWait(browser, TimeSpan.FromSeconds(2));

            waitForElement.Until(
                ExpectedConditions
                    .ElementIsVisible(By.CssSelector($"div[class='{GlobalSearchSongClass}']"))
            );

            if (searchOnlyInUserSongs)
            {
                IWebElement songsContainer = browser.FindElement(
                    By.ClassName(UserAudioSearchContainerClass)
                );

                songs = songsContainer.FindElements(
                    By.ClassName(SongRowClass)
                );
            }
            else
            {
                songs = browser.FindElements(
                    By.ClassName(SongRowClass)
                );
            }

            return ParseSongsList(songs);
        }

        public void SwitchPlayback(IWebDriver browser)
        {
            IWebElement playbackButton = browser.FindElement(
                By.ClassName(PlaybackButtonClass)
            );

            playbackButton.Click();
        }
    }
}