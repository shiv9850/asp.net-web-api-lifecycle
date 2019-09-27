using Lifecycle.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Lifecycle.Handlers
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        public CustomControllerSelector(HttpConfiguration  httpConfiguration) : base(httpConfiguration)
        {

        }

        
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {

            if (request.Properties.ContainsKey("UseCustomSelector") && (request.Properties["UseCustomSelector"] as bool?) == true)
            {
                (request.GetDependencyScope().GetService(typeof(ILogger<CustomControllerSelector>)) as ILogger<CustomControllerSelector>).Info("in custom controller selector");
                //return base.SelectController(request);
                var controllers = GetControllerMapping();
                HttpControllerDescriptor httpControllerDescriptor;
                controllers.TryGetValue("PerRoute", out httpControllerDescriptor);
                request.Properties["usecustomAction"] = true;
                return httpControllerDescriptor; 
            }

            return base.SelectController(request);
        }
    }
}