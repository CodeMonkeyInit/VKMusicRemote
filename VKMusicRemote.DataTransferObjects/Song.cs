using System.Runtime.Serialization;

namespace VKMusicRemote.DataTransferObjects
{
    [DataContract]
    public class Song
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Artist { get; set; }

        [DataMember]
        public string Album { get; set; }

        [DataMember]
        public string Length { get; set; }
    }
}
