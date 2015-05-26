using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC
{
    public interface IControllerFactory
    {
        IController CreateController(string controllerName,RequestContext requestContext);
    }
}
