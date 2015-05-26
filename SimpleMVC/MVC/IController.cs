using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC
{
    public interface IController
    {
        void Execute(RequestContext requestContext);
    }
}
