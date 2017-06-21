using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using VKMusicRemote.CastleInstaller;

namespace VKMusicRemote.CastleWindsor
{
	public class ServicesContainer
	{
        public static IWindsorContainer Container { get; } = new WindsorContainer()
            .Install(new ServicesWindsorInstaller());
	}
}