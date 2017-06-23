using System.Collections.Generic;
using System.ServiceModel;
using VKMusicRemote.DataTransferObjects;

namespace VKMusicRemote.ServicesContracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMusicService" in both code and config file together.
    [ServiceContract]
    public interface IMusicService
    {
        [OperationContract]
        ICollection<Song> GetUserMusic();

        [OperationContract]
        bool PlaySong(Song song);

        [OperationContract]
        ICollection<Song> SearchSongs(string criterea, bool searchOnlyInUserSongs = false);

        [OperationContract]
        bool SwitchPlayback();
    }
}
