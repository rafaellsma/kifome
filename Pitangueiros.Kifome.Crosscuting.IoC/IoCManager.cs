using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitangueiros.Kifome.Crosscuting.IoC
{
    public class IocManager
    {
        static IocManager()
        {
            Instance = new IocManager();
        }
        public static IocManager Instance { get; private set; }

        public IWindsorContainer IocContainer { get; private set; }
    }
}
