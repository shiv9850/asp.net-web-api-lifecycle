using Lifecycle.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace Lifecycle.Dependency
{
    public static class DependencyConfig
    {
        static IUnityContainer Container { get; } = new UnityContainer();
        public static IUnityContainer Register()
        {
            AddSingltone();
            return Container;
        }

        private static void AddSingltone()
        {
            Container.RegisterType(typeof(ILogger<>), typeof(Logger<>),new HierarchicalLifetimeManager());
        }
    }
}