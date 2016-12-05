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
            _driver.FindElement(locator).Clear();
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
        
        protected void Unhide(IWebElement element)
        {
            String script = "arguments[0].style.opacity=1;"
              + "arguments[0].style['transform']='translate(0px, 0px) scale(1)';"
              + "arguments[0].style['MozTransform']='translate(0px, 0px) scale(1)';"
              + "arguments[0].style['WebkitTransform']='translate(0px, 0px) scale(1)';"
              + "arguments[0].style['msTransform']='translate(0px, 0px) scale(1)';"
              + "arguments[0].style['OTransform']='translate(0px, 0px) scale(1)';"
              + "return true;";
            _driver.ExecuteJavaScript(script, element);
        }

        protected void SetDatepicker(string cssSelector, string date)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until<bool>(
                d => _driver.FindElement(By.CssSelector(cssSelector)).Displayed);
            (_driver as IJavaScriptExecutor).ExecuteScript(
                String.Format("$('{0}').datepicker('setDate', '{1}')", cssSelector, date));
        }
        
        protected void FindAndClickLinkByText(string linkText)
        {
            _driver.FindElement(By.XPath("//a[contains(.,'" + linkText + "')]")).Click();
        }

        protected void UploadFile(By locator, string filePath)
        {
            IWebElement fileUpload = _driver.FindElement(locator);
            Unhide(fileUpload);
            fileUpload.SendKeys(filePath);
        }
    }
}
