using Castle.Windsor;

namespace Pitang.Kifome.Crosscuting.IoC
{
    public class IocManager
    {
        public static IocManager Instance { get; private set; }

        public IWindsorContainer IocContainer { get; private set; }

        static IocManager()
        {
            Instance = new IocManager();
        }
       
        public IocManager()
        {
            this.IocContainer = new WindsorContainer();
        }
    }
}
