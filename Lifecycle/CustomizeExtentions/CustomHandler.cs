using Lifecycle.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Lifecycle.Handlers
{
    public class CustomHandler : DelegatingHandler
    {
        
        public CustomHandler()
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

           var scope = request.GetDependencyScope();
           ILogger<CustomHandler> logger = scope.GetService(typeof(ILogger<CustomHandler>)) as ILogger<CustomHandler>;
            logger.Info(request);
            return base.SendAsync(request, cancellationToken);
        }
    }
}