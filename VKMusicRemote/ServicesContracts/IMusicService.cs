using System.ServiceModel;

namespace VKMusicRemote.ServicesContracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMusicService" in both code and config file together.
    [ServiceContract]
    public interface IMusicService
    {
        [OperationContract]
        void DoWork();
    }
}
