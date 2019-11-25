
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using api;

namespace SlaterIntegrationTest
{
    [TestFixture]
    public class Defcon_Chrome_Tests
    {
        private IWebDriver driver;
        public string homeURL;


        [Test(Description = "Check Defcon Login")]
        public void Login()
        {
            homeURL = "http://localhost:5001/";
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver,
System.TimeSpan.FromSeconds(5));
            driver.FindElement(By.Id("signin")).Click();
            IWebElement email = driver.FindElement(By.Id("loginEmail"));
            IWebElement password = driver.FindElement(By.Id("loginPassword"));

            email.SendKeys("test@Mail.com");
            password.SendKeys("Random123!");
            driver.FindElement(By.Id("signin")).Click();

        }


        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }


        [SetUp]
        public void SetupTest()
        {
            homeURL = "http://localhost:5001/";
            driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://www.google.com");
        }


    }


}