﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SimpleMVC
{
    public class MvcHandler:IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public RequestContext RequestContext { get; set; }
        public MvcHandler(RequestContext requestContext)
        {
            this.RequestContext = requestContext;
        }
        public void ProcessRequest(HttpContext context)
        {
            string controllerName = this.RequestContext.RouteData.Controller;
            IControllerFactory controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            IController controller= controllerFactory.CreateController(controllerName, RequestContext);
            controller.Execute(RequestContext);
        }
    }
}
