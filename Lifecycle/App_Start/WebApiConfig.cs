using Lifecycle.CustomizeExtentions;
using Lifecycle.Dependency;
using Lifecycle.Handlers;
using Lifecycle.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Lifecycle
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
              name: "privateApi",
              routeTemplate: "api/private/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional },
              constraints: null,
              handler: new PerRouteHandler(config)
          );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           

            var dependencyResolver = new DependencyResolver(DependencyConfig.Register);
            config.DependencyResolver = dependencyResolver;

            config.MessageHandlers.Add(new CustomHandler());

            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));

            config.Services.Replace(typeof(IHttpActionSelector), new CustomActionSelector());
        }
    }
}
