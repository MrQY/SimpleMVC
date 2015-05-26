using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SimpleMVC
{
    public class ControllerActionInvoker:IActionInvoker
    {
        public IModelBinder ModelBinder { get; private set; }
        public ControllerActionInvoker()
        {
            ModelBinder = new DefaultModelBinder();
        }
        public void InvokeAction(ControllerContext controllerContext, string actionName)
        {
            MethodInfo methodInfo = controllerContext.Controller.GetType().GetMethods().FirstOrDefault(m=>string.Compare(actionName, m.Name, true) == 0);
            List<object> parameters = new List<object>();
            foreach (var item in methodInfo.GetParameters())
            {
                parameters.Add(this.ModelBinder.BindModel(controllerContext, item.Name, item.ParameterType));
            }
            ActionExecutor executor = new ActionExecutor(methodInfo);
            ActionResult actionResult=(ActionResult)executor.Execute(controllerContext.Controller, parameters.ToArray());
            actionResult.ExecuteResult(controllerContext);
        }
    }
}