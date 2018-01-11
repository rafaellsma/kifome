using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitang.Kifome.Infra.Repositories.Repository;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Pitang.Kifome.Infra.Repositories.IoC
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUserRepository, UserRepository>(),
                Component.For<ICommentRepository, CommentRepository>(),
                //Component.For<IConversationRepository, ConversationRepository>(),
                Component.For<ICustomerRepository, CustomerRepository>(),
                Component.For<IDeliveryRepository, DeliveryRepository>(),
                Component.For<IGarnishRepository, GarnishRepository>(),
                Component.For<IMealRepository, MealRepository>(),
                Component.For<IMenuRepository, MenuRepository>(),
                Component.For<IOrderRepository, OrderRepository>(),
                Component.For<ISellerRepository, SellerRepository>()
            );
        }
    }
}
