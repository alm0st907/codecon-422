
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
        public QueryEngine EngineUnderTest;

        private IWebDriver driver;
        public string homeURL;


        [Test(Description = "Check Defcon Login")]
        public void Login()
        {
            homeURL = "http://localhost:5001/";
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver,
System.TimeSpan.FromSeconds(20));
            driver.FindElement(By.Id("signin")).Click();
            IWebElement email = driver.FindElement(By.Id("loginEmail"));
            IWebElement password = driver.FindElement(By.Id("loginPassword"));

            email.SendKeys("test@Mail.com");
            password.SendKeys("Random123!");
            driver.FindElement(By.Id("signin")).Click();

        }

        [Test(Description = "Now populate task window")]
        public void CreateTask()
        {
            homeURL = "http://localhost:5001/issues";
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver,
System.TimeSpan.FromSeconds(20));
            IWebElement issueName=driver.FindElement(By.Id("issueName"));
            IWebElement issueUser = driver.FindElement(By.Id("issueAssignee"));

            IWebElement issueLevel = driver.FindElement(By.Id("issueDefconLevel"));
            IWebElement issueDesc = driver.FindElement(By.Id("issueDescription"));



            issueName.SendKeys("testIssue123");
            issueUser.SendKeys("Slater");
            issueLevel.SendKeys("4");
            issueDesc.SendKeys("omg we have an issue, hurry....");

            driver.FindElement(By.Id("scale")).Click();






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