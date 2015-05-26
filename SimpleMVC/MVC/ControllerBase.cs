using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC
{
    public class ControllerBase:IController
    {
        public IActionInvoker ActionInvoker { get; set; }

        public ControllerBase()
        {
            ActionInvoker = new ControllerActionInvoker();
        }
        public void Execute(RequestContext requestContext)
        {
            ControllerContext context = new ControllerContext
            {
                RequestContext = requestContext,
                Controller = this
            };
            ActionInvoker.InvokeAction(context, requestContext.RouteData.Action);
        }
    }
}