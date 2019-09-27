using Lifecycle.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lifecycle.Controllers
{
    public class PerRouteController : ApiController
    {

        ILogger<PerRouteController> logger;
        public PerRouteController(ILogger<PerRouteController> logger)
        {
            this.logger = logger;
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet]
        [ActionName("Get1")]
        public IEnumerable<string> Get1()
        {
            logger.Info("Get1");
            return new string[] { "value1", "value2" };
        }
    }
}
