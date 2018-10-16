using Xunit;
using wtwTest.Models;
using wtwTest;

namespace Tests
{
    public class EmailServiceTests
    {
        [Fact]
        public void RegisterAndResolve()
        {
            var container = new IocContainer();
            container.Register<IEmailService, EmailService>();
            var emailService = container.Resolve(typeof(IEmailService)) as EmailService;
            Assert.NotNull(emailService);
            const string testString = "Works";
            emailService.Input = testString;
            Assert.Equal(emailService.Retrieve(), testString);
            Assert.NotEqual(emailService.Retrieve(), $"{testString}!");
        }
    }
}
