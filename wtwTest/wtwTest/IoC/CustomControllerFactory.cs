using System;
using System.Web.Mvc;
using System.Web.Routing;
using wtwTest.Controllers;

namespace wtwTest {
    public class CustomControllerFactory : DefaultControllerFactory
    {
        public CustomControllerFactory() 
        {
            IocContainer = new IocContainer();
            BootStrapper.Configure(IocContainer);
            
        }
        public IocContainer IocContainer { get; set; }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllername = requestContext.RouteData.Values["controller"].ToString();
            var controllerType = Type.GetType($"wtwTest.Controllers.{controllername}Controller");

            // I'm just going to assume that only the User Controller is retrieved from the custom IoC Controller, all others will use the default behavior.
            IController controller = null;
            if (controllerName == "Users")
            {
                controller = IocContainer.Resolve<UsersBaseController>();
            }
            else
            {
                controller = Activator.CreateInstance(controllerType) as IController;
            }
            return controller;
        }
        public override void ReleaseController(IController controller)
        {
            var dispose = controller as IDisposable;
            dispose?.Dispose();
        }
    }
}