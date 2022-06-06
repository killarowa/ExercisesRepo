using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            //To start test w/o a browser instance/headless/ (if test are included in CI flow)
            var options = new ChromeOptions();
            //options.AddArguments("--headless", "--windows-size=1920,1200");

            this.driver = new ChromeDriver(options);
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
            
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://softuni.bg/");

            //Act
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void Test_AssertAboutUsTitle()
        {

            driver.Manage().Window.Maximize();

            //Act
            var zaNasElement = driver.FindElement(By.LinkText("За нас"));
            zaNasElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";


            //Assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void Test_Login_InvalidUsernameAndPassword()
        {
            driver.Navigate().GoToUrl("https://softuni.bg/");
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();
            driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.Id("password-input")).SendKeys("password");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            driver.FindElement(By.CssSelector("li")).Click();
            var elements = driver.FindElements(By.CssSelector("li"));
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
         }

        [Test]
        public void Test_SearchField()
        {
            driver.Url = "https://softuni.bg";

            var searchField = driver.FindElement(By.CssSelector(".header-search-dropdown-link .fa-search"));

            searchField.Click();

            var searchBox = driver.FindElement(By.CssSelector(".container > form #search-input"));
            searchBox.Click();
            searchBox.SendKeys("QA" + Keys.Enter);

            var resultField = driver.FindElement(By.CssSelector(".search-title")).Text;

            var expectedValue = "Резултати от търсене на “QA”";

            Assert.That(resultField, Is.EqualTo(expectedValue));


        }

        
        }
    }
















        //lection: Selenium Advanced and POM

}