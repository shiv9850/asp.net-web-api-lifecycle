using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace Lifecycle.Dependency
{
    public class DependencyResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public DependencyResolver(Func<IUnityContainer> container)
        {
            this.container = container();
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new DependencyResolver(()=> child);
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
    }
}