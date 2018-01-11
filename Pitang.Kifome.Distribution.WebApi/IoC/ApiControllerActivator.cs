using Pitang.Kifome.Crosscuting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Pitang.Kifome.Distribution.WebApi.IoC
{
    public class ApiControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller =
            (IHttpController)IocManager.Instance.IocContainer.Resolve(controllerType);

            request.RegisterForDispose(
                new Release(
                    () => IocManager.Instance.IocContainer.Release(controller)));

            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action _release;

            public Release(Action release)
            {
                _release = release;
            }

            public void Dispose()
            {
                _release();
            }
        }

    }
}