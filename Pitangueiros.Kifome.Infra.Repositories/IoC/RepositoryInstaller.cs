using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Pitang.Kifome.Domain.Contracts.Repositories;
using Pitangueiros.Kifome.Infra.Repositories.Repository;

namespace Pitangueiros.Kifome.Infra.Repositories.IoC
{
    class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUserRepository, UserRepository>(),
                Component.For<ICommentRepository, CommentRepository>(),
                Component.For<IConversationRepository, ConversationRepository>(),
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
