using wtwTest.Controllers;
using wtwTest.Models;

namespace wtwTest
{
    public static class BootStrapper
    {
        public static void Configure(IocContainer container)
        {
            //container.Register<UsersBaseController, AlternativeUsersController>();
            container.Register<UsersBaseController, UsersController>();
            container.Register<ICalculator, Calculator>();
            container.Register<IEmailService, EmailService>(LifecycleType.Singleton);
        }
    }
}