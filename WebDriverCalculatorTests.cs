using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTests
    {

        private ChromeDriver driver;
        //private FirefoxDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            //this.driver = new FirefoxDriver();

            driver.Url = "https://number-calculator.nakov.repl.co/";
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }



        [TestCase("5", "6", "+", "Result: 11")]
        [TestCase("15", "6", "-", "Result: 9")]
        [TestCase("15", "1", "-", "Result: 14")]
        [TestCase("10", "2", "/", "Result: 5")]
        [TestCase("10", "2", "*", "Result: 20")]
        [TestCase("1000000", "2000000", "-", "Result: -1000000")]
        [TestCase("alabala", "alabala", "-", "Result: invalid input")]
        public void Test_Calculator(string num1, string num2, string action, string result)
        {
            //Arrange:
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearField = driver.FindElement(By.Id("resetButton"));

            //Act:
            field1.Click();
            field1.SendKeys(num1);
            operation.SendKeys(action);
            field2.SendKeys(num2);

            calculate.Click();

            //Assert:
            Assert.That(result, Is.EqualTo(resultField.Text));
            clearField.Click();

        }
    }
}