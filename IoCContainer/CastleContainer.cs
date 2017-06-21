using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;

namespace IoCContainer
{
    public class CastleContainer
    {
        public static IWindsorContainer Container { get; } = new WindsorContainer();
        
        private CastleContainer()
        {
            
        }
    }
}
