using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace VKMusicRemote.Selenium.Cookies
{
    public interface ICookieManager
    {
        ICollection<Cookie> GetCookies();
        void SaveCookies(ICollection<Cookie> cookies);
    }
}