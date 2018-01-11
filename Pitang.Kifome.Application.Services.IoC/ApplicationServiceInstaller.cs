﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Pitang.Kifome.Application.Contracts.Services;
using Pitang.Kifome.Application.Services.Implementation;

namespace Pitang.Kifome.Application.Services.IoC
{
    public class ApplicationServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUserAppService, UserAppService>()
            );
        }
    }
}
