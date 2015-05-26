using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC
{
    public class RouteDictionary:Dictionary<string,RouteBase>
    {
        public RouteData GetRouteData(HttpContextBase httpContext)
        {
            foreach (var item in this.Values)
            {
                RouteData routeData = item.GetRouteData(httpContext);
                if (null != routeData)
                    return routeData;
            }
            return null;
        }
    }
}