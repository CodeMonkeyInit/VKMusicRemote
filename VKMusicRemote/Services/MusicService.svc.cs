using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Castle.Windsor;
using VKMusicRemote.CastleWindsor;
using VKMusicRemote.DataTransferObjects;
using VKMusicRemote.Selenium;
using VKMusicRemote.ServicesContracts;

namespace VKMusicRemote.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MusicService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MusicService.svc or MusicService.svc.cs at the Solution Explorer and start debugging.
    public class MusicService : IMusicService
    {
        private readonly IWindsorContainer _container = ServicesContainer.Container;
        private readonly IVkClient _vkClient;

        public MusicService()
        {
            _vkClient = _container.Resolve<IVkClient>();
        }

        public ICollection<Song> GetUserMusic()
        {
            return _vkClient.GetUserMusic();
        }

        public bool PlaySong(Song song)
        {
            return _vkClient.PlaySong(song);
        }

        public ICollection<Song> SearchSongs(string criterea, bool searchOnlyInUserSongs = false)
        {
            return _vkClient.SearchSongs(criterea, searchOnlyInUserSongs);
        }

        public bool SwitchPlayback()
        {
            return _vkClient.SwitchPlayback();
        }
    }
}
