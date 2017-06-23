using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using Castle.Core.Internal;
using Newtonsoft.Json;
using OpenQA.Selenium;
using VKMusicRemote.DataTransferObjects;

namespace VKMusicRemote.Selenium.Cookies
{
    public class CookieManager : ICookieManager
    {
        private const string CookiesFilePath = "vkremote.ini";

        public ICollection<Cookie> GetCookies()
        {
            if (!File.Exists(CookiesFilePath))
            {
                return null;
            }

            Mapper.Initialize(config => config.CreateMap<SerializebleCookie, Cookie>());
            
            string serializedCookies = File.ReadAllText(CookiesFilePath);

            var serializebleCookies = JsonConvert.DeserializeObject<ICollection<SerializebleCookie>>(serializedCookies);

            var cookies = Mapper.Map<ICollection<Cookie>>(serializebleCookies);

            return cookies;
        }

        public void SaveCookies(ICollection<Cookie> cookies)
        {
            Mapper.Initialize(config => config.CreateMap<Cookie, SerializebleCookie>());

            var serializebleCookies = Mapper.Map<ICollection<SerializebleCookie>>(cookies);

            string serializedCookies = JsonConvert.SerializeObject(serializebleCookies, Formatting.Indented);

            File.WriteAllText(CookiesFilePath, serializedCookies);
        }
    }
}
