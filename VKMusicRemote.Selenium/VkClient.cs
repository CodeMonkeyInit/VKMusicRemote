using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Castle.Windsor;
using OpenQA.Selenium;
using VKMusicRemote.DataTransferObjects;
using VKMusicRemote.Selenium.CastleInstaller;
using VKMusicRemote.Selenium.Cookies;
using VKMusicRemote.Selenium.Login;

namespace VKMusicRemote.Selenium
{
    public class VkClient : IVkClient
    {
        private readonly IWindsorContainer _container;
        private readonly IWebDriver _browserDriver;
        private readonly IVkLoginManager _vkLoginManager;
        private readonly IVkRemoteMusic _vkRemoteMusic;
        private readonly ICookieManager _cookieManager;

        public const string VkLoginPage = @"https://vk.com/";

        public bool IsLogged => _vkLoginManager.IsLogged(_browserDriver);
        
        private void RestoreCookies()
        {
            ICollection<Cookie> cookies = _cookieManager.GetCookies();

            _browserDriver.Url = VkLoginPage;

            if (cookies != null)
            {
                foreach (Cookie cookie in cookies)
                {
                    _browserDriver.Manage().Cookies.AddCookie(cookie);
                }
            }

            _browserDriver.Navigate().Refresh();
        }

        private void SaveCookies()
        {
            ReadOnlyCollection<Cookie> cookies = _browserDriver.Manage().Cookies.AllCookies;

            _cookieManager.SaveCookies(cookies);
        }

        public bool Logout()
        {
            return _vkLoginManager.Logout(_browserDriver);
        }

        public LoginInformation Login(string login, string password)
        {
            if (IsLogged)
            {
                Logout();
            }

            _browserDriver.Url = VkLoginPage;

            LoginInformation loginInformation = _vkLoginManager.Login(login, password, _browserDriver);

            if (loginInformation.Success)
            {
                SaveCookies();
            }

            return loginInformation;
        }

        public bool TwoFactorAuthentication(string code)
        {
            bool authenticationSuccessfull = _vkLoginManager.TwoFactorAuthentication(code, _browserDriver);

            if (authenticationSuccessfull)
            {
                SaveCookies();
            }

            return authenticationSuccessfull;
        }

        public ICollection<Song> GetUserMusic()
        {
            return _vkRemoteMusic.GetUserMusic(_browserDriver);
        }

        public bool PlaySong(Song song)
        {
            try
            {
                _vkRemoteMusic.PlaySong(_browserDriver, song);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public ICollection<Song> SearchSongs(string criterea, bool searchOnlyInUserSongs = false)
        {
            return _vkRemoteMusic.SearchSongs(_browserDriver, criterea, searchOnlyInUserSongs);
        }

        public bool SwitchPlayback()
        {
            try
            {
                _vkRemoteMusic.SwitchPlayback(_browserDriver);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public VkClient()
        {
            //TODO create static windsor container
            _container = new WindsorContainer().Install(new VkRemoteCastleInstaller());
            _browserDriver = _container.Resolve<IWebDriver>();
            _vkLoginManager = _container.Resolve<IVkLoginManager>();
            _vkRemoteMusic = _container.Resolve<IVkRemoteMusic>();
            _cookieManager = _container.Resolve<ICookieManager>();

            RestoreCookies();
        }
    }
}