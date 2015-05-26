using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC
{
    public class RequestContext
    {
        public virtual HttpContextBase HttpContext { get; set; }

        public virtual RouteData RouteData { get; set; }
    }
}