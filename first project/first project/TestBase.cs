using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace first_project
{
    [TestFixture]
    public class TestBase
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        [SetUp]
        public void Start()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void Stop()
        {
            _driver.Quit();
            _driver = null;
        }

        protected void LogintoAdminPanel()
        {
            _driver.Url = "http://localhost:81/litecart/admin/";
            _driver.FindElement(By.Name("username")).SendKeys("admin");
            _driver.FindElement(By.Name("password")).SendKeys("admin");
            _driver.FindElement(By.Name("login")).Click();
            _wait.Until(ExpectedConditions.ElementExists(By.Id("box-apps-menu")));
        }
        protected void OpenHomePage()
        {
            _driver.Url = "http://localhost:81/litecart/";
        }

        protected void FillInput(By locator, string inputValue)
        {
            _driver.FindElement(locator).SendKeys(inputValue);
        }

        protected void HiddenSelectOptionSelect(By locator, string value)
        {
            IWebElement select = _driver.FindElement(locator);
            _driver.ExecuteJavaScript("arguments[0].style.opacity=1;", select);
            SelectElement selectElement = new SelectElement(select);
            selectElement.SelectByValue(value);
        }
        protected void Logout()
        {
            _driver.FindElement(By.XPath("//a[contains(.,'Logout')]")).Click();
        }
    }
}
