using Lifecycle.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lifecycle.Controllers
{
    public class ValuesController : ApiController
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public ValuesController(ILogger<ValuesController> logger)
        {
            logger.Info("OK");
        }
        [HttpGet]
        [ActionName("GetValues")]
        public IHttpActionResult Get(string message)
        {
            try
            {
                //Logger.Log(NLog.LogLevel.Trace, "Trace");
                //Logger.Log(NLog.LogLevel.Debug, "Debug ");
                //Logger.Log(NLog.LogLevel.Info, "INfo");
                //Logger.Log(NLog.LogLevel.Warn, "Warn");
                //Logger.Log(NLog.LogLevel.Error, "Error");
                //Logger.Log(NLog.LogLevel.Fatal, "Fatal");
                //Logger.Info(Request);
                return Ok<string>(message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception occured while getting values");
                return InternalServerError(ex);
            }
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
