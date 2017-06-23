using System.Runtime.Serialization;

namespace VKMusicRemote.DataTransferObjects
{
    [DataContract]
    public class LoginInformation
    {
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public LoginError ErrorType { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

    }
}