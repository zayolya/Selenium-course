using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace first_project
{
  
    [TestFixture]
    public class LoginToAdminPanelTest
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void Start()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestMethod1()
        {
            _driver.Url = "http://localhost:81/litecart/admin/";
            _driver.FindElement(By.Name("username")).SendKeys("admin");
            _driver.FindElement(By.Name("password")).SendKeys("admin");
            _driver.FindElement(By.Name("login")).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.Id("box-apps-menu")));
        }
        [TearDown]
        public void Stop()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
