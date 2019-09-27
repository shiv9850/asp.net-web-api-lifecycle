using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace Lifecycle.CustomizeExtentions
{
    public class CustomActionSelector : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            if (controllerContext.Request.Properties.ContainsKey("usecustomAction") && (controllerContext.Request.Properties["usecustomAction"] as bool?) == true)
            {
                var actions = GetActionMapping(controllerContext.ControllerDescriptor);
                var action = actions.FirstOrDefault(item => item.Key == "Get1")?.FirstOrDefault();
                return action;
            }
            return base.SelectAction(controllerContext);
        }
    }
}