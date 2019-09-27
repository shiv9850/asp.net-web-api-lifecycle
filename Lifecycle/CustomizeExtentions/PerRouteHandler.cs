using Lifecycle.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Lifecycle.Handlers
{
    public class PerRouteHandler : DelegatingHandler
    {
        public PerRouteHandler(HttpConfiguration httpConfiguration)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfiguration);
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            request.Properties["UseCustomSelector"] = true;

            (request.GetDependencyScope().GetService(typeof(ILogger<PerRouteHandler>)) as ILogger<PerRouteHandler>).Info("PerRouteHandler");

            return base.SendAsync(request, cancellationToken);
        }
    }
}