using Xunit;
using wtwTest;
using wtwTest.Controllers;
using wtwTest.Models;

namespace Tests
{
    public class UsersControllerTests
    {
        [Fact]
        public void RegisterAndResolveAlternativeController()
        {
            var container = new IocContainer();
            container.Register<UsersBaseController, AlternativeUsersController>();
            var usersController = container.Resolve(typeof(UsersBaseController)) as AlternativeUsersController;
            Assert.NotNull(usersController);
        }

        [Fact]
        public void VerifyParametersAreResolved()
        {
            var container = new IocContainer();
            container.Register<ICalculator, Calculator>();
            container.Register<IEmailService, EmailService>();
            container.Register<UsersBaseController, UsersController>();

            var usersController = container.Resolve(typeof(UsersBaseController)) as UsersController;
            Assert.NotNull(usersController);
            Assert.NotNull(usersController.Calculator);
            Assert.NotNull(usersController.EmailService);
        }

        [Fact]
        public void VerifyNoParametersAreResolvedForAlternative()
        {
            var container = new IocContainer();
            container.Register<ICalculator, Calculator>();
            container.Register<IEmailService, EmailService>();
            container.Register<UsersBaseController, AlternativeUsersController>();

            var usersController = container.Resolve(typeof(UsersBaseController)) as AlternativeUsersController;
            Assert.NotNull(usersController);
            Assert.Null(usersController.Calculator);
            Assert.Null(usersController.EmailService);
        }
    }
}
