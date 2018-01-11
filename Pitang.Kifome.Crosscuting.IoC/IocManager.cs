using Castle.Windsor;


namespace Pitang.Kifome.Crosscuting.IoC
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
