using System.Web.Mvc;
using wtwTest.Models;

namespace wtwTest.Controllers {

    // Base class and two UserController options to allow testing of swapping controllers

    public abstract class UsersBaseController : Controller
    {
        public ICalculator Calculator { get; set; }
        public IEmailService EmailService { get; set; }
    }

    public class UsersController : UsersBaseController
    {
        public UsersController(ICalculator calculator, IEmailService emailService)
        {
            Calculator = calculator;
            EmailService = emailService;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Primary Users Controller";
            return View();
        }
    }

    public class AlternativeUsersController : UsersBaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Alternative Users Controller";
            return View("~/Views/Users/Index.cshtml");
        }
    }

}