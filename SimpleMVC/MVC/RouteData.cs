using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC
{
    public class RouteData
    {
        public IDictionary<string,object> Values { get; set; }
        public IDictionary<string,object> DataTokens { get; set; }
        public IRouteHandler RouteHandler { get; set; }
        public RouteBase Route { get; set; }
        public RouteData()
        {
            this.Values = new Dictionary<string, object>();
            this.DataTokens = new Dictionary<string, object>();
            this.DataTokens.Add("namespaces", new List<string>());
        }

        public string Controller
        {
            get
            {
                object controllerName = string.Empty;
                Values.TryGetValue("controller", out controllerName);
                return controllerName.ToString();
            }
        }

        public string Action
        {
            get
            {
                object action = string.Empty;
                Values.TryGetValue("action", out action);
                return action.ToString();
            }
        }
    }
}