using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKMusicRemote.DataTransferObjects
{
    public class SerializebleCookie
    {
        public string Name { get; set; }
        
        public string Value { get; set; }

        public string Domain { get; set; }
        
        public virtual string Path { get; set; }
        
        public virtual bool Secure { get; set; }
        
        public virtual bool IsHttpOnly { get; set; }
        
        public DateTime? Expiry { get; set; }

        public SerializebleCookie()
        {
            
        }
    }
}
