using System;
using Xunit;
using wtwTest.Models;
using wtwTest;

namespace Tests
{

    public class CalculatorAndIocTests
    {
        [Fact]
        public void Register()
        {
            var container = new IocContainer();
            try
            {
                container.Register<ICalculator, Calculator>();
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }

        [Fact]
        public void RegisterSingleton()
        {
            var container = new IocContainer();
            try
            {
                container.Register<ICalculator, Calculator>(LifecycleType.Singleton);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }

        [Fact]
        public void RegisterAndResolve()
        {
            var container = new IocContainer();
            container.Register<ICalculator, Calculator>();
            var calculator = container.Resolve(typeof(ICalculator)) as Calculator;
            Assert.NotNull(calculator);
            calculator.Input = 11.5;
            Assert.Equal(calculator.Calculate(), 10.5);
        }

        [Fact]
        public void RegisterAndResolveSingleton()
        {
            var container = new IocContainer();
            container.Register<ICalculator, Calculator>(LifecycleType.Singleton);
            var calculator = container.Resolve(typeof(ICalculator)) as Calculator;
            Assert.NotNull(calculator);
            calculator.Input = 11.5;
            Assert.Equal(calculator.Calculate(), 10.5);
        }
        
        [Fact]
        public void VerifyTransient()
        {
            var container = new IocContainer();
            container.Register<ICalculator, Calculator>();
            var calculator = container.Resolve(typeof(ICalculator)) as Calculator;
            Assert.NotNull(calculator);
            var calculator2 = container.Resolve(typeof(ICalculator)) as Calculator;
            Assert.NotNull(calculator2);
            Assert.NotEqual(calculator, calculator2);
        }

        [Fact]
        public void VerifySingleton()
        {
            var container = new IocContainer();
            container.Register<ICalculator, Calculator>(LifecycleType.Singleton);
            var calculator = container.Resolve(typeof(ICalculator)) as Calculator;
            Assert.NotNull(calculator);
            var calculator2 = container.Resolve(typeof(ICalculator)) as Calculator;
            Assert.NotNull(calculator2);
            Assert.Same(calculator, calculator2);
        }



    }
}
