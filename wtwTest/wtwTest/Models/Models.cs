
namespace wtwTest.Models
{

    // Calculator
    public interface ICalculator
    {
        double Input { get; set; }
        double Calculate();
    }
    public class Calculator : ICalculator
    {
        public double Input { get; set; }
        public double Calculate() => Input - 1;
    }

    // EmailService
    public interface IEmailService
    {
        string Input { get; set; }
        string Retrieve();
    }
    public class EmailService : IEmailService
    {
        public string Input { get; set; }
        public string Retrieve() => Input;
    }
}