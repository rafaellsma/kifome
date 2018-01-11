﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Pitang.Kifome.Distribution.WebApi.IoC
{
    public class ApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
              Classes.
                FromThisAssembly().
                BasedOn<ApiController>(). //Web API
                If(c => c.Name.EndsWith("Controller")).
                LifestyleTransient()
            );
        }
    }
}