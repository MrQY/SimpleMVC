using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Compilation;

namespace SimpleMVC
{
    public class DefaultControllerFactory:IControllerFactory
    {
        private static List<Type> controllerTypes = new List<Type>();

        public DefaultControllerFactory()
        {
            foreach (Assembly assembly in BuildManager.GetReferencedAssemblies())
            {
                foreach (Type type in assembly.GetTypes().Where(o=>typeof(IController).IsAssignableFrom(o)))
                {
                    controllerTypes.Add(type);
                }
            }
        }
        public IController CreateController(string controllerName, RequestContext requestContext)
        {
            string typeName = controllerName + "Controller";
            Type controllerType = controllerTypes.FirstOrDefault(o => string.Compare(typeName, o.Name, true) == 0);
            if (null == controllerType)
            {
                return null;
            }
            return (IController)Activator.CreateInstance(controllerType);
        }
    }
}