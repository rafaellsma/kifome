using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Pitang.Kifome.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Kifome.Domain.Contracts.Services;
using Pitang.Kifome.Domain.Services.Implementation;

namespace Pitang.Kifome.Domain.Services.IoC
{
    public class DomainServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ICustomerService, CustomerService>(),
                Component.For<ISellerService, SellerService>(),
                Component.For<IUserService, UserService>()
            );
        }
    }
}
