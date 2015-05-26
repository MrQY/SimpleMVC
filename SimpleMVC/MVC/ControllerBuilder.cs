using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC
{
    public class ControllerBuilder
    {
        private Func<IControllerFactory> factoryTrunk;

        public static ControllerBuilder Current { get; private set; }
        static ControllerBuilder()
        {
            Current = new ControllerBuilder();
        }

        public IControllerFactory GetControllerFactory()
        {
            return factoryTrunk();
        }
        public void SetControllerFactory(IControllerFactory controllerFactory)
        {
            factoryTrunk = () => controllerFactory;
        }
    }
}