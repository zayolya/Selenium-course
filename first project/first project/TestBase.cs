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
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        int timeOutInSec = 10;

        [SetUp]
        public void Start()
        {
            Driver = new ChromeDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutInSec));
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeOutInSec));
        }

        [TearDown]
        public void Stop()
        {
            Driver.Quit();
            Driver = null;
        }

        protected void LogintoAdminPanel()
        {
            Driver.Url = "http://localhost:81/litecart/admin/";
            Driver.FindElement(By.Name("username")).SendKeys("admin");
            Driver.FindElement(By.Name("password")).SendKeys("admin");
            Driver.FindElement(By.Name("login")).Click();
            Wait.Until(ExpectedConditions.ElementExists(By.Id("box-apps-menu")));
        }
        protected void OpenHomePage()
        {
            Driver.Url = "http://localhost:81/litecart/";
        }

        protected void FillInput(By locator, string inputValue)
        {
            Driver.FindElement(locator).Clear();
            Driver.FindElement(locator).SendKeys(inputValue);
        }

        protected void HiddenSelectOptionSelect(By locator, string value)
        {
            IWebElement select = Driver.FindElement(locator);
            Driver.ExecuteJavaScript("arguments[0].style.opacity=1;", select);
            SelectElement selectElement = new SelectElement(select);
            selectElement.SelectByValue(value);
        }

        protected void SelectOptionSelect(By locator, int selectIndex)
        {
            IWebElement select = Driver.FindElement(locator);
            SelectElement selectElement = new SelectElement(select);
            selectElement.SelectByIndex(selectIndex);
        }
        
        protected void Logout()
        {
            Driver.FindElement(By.XPath("//a[contains(.,'Logout')]")).Click();
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
            Driver.ExecuteJavaScript(script, element);
        }

        protected void SetDatepicker(string cssSelector, string date)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(30)).Until<bool>(
                d => Driver.FindElement(By.CssSelector(cssSelector)).Displayed);
            (Driver as IJavaScriptExecutor).ExecuteScript(
                String.Format("$('{0}').datepicker('setDate', '{1}')", cssSelector, date));
        }
        
        protected void FindAndClickLinkByText(string linkText)
        {
            Driver.FindElement(By.XPath("//a[contains(.,'" + linkText + "')]")).Click();
        }

        protected void UploadFile(By locator, string filePath)
        {
            IWebElement fileUpload = Driver.FindElement(locator);
            Unhide(fileUpload);
            fileUpload.SendKeys(filePath);
        }

        protected IWebElement WaitForElement(By locator)
        {
            return Wait.Until(d => d.FindElement(locator));
        }
        
        protected IWebElement WaitForElementExists(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementExists(locator));
        }
        
        protected bool IsElementPresent(By locator)
        {
            try
            {
                Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
                return Driver.FindElements(locator).Count > 0;
            }
            finally
            {
                Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
            }
        }

        protected bool IsElementNotPresent(By locator)
        {
            try
            {
                Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
                return Driver.FindElements(locator).Count == 0;
            }
            finally
            {
                Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeOutInSec));
            }
        }

        protected void WaitForElementDisappear(IWebElement element)
        {
            Driver.Navigate().Refresh();
            Wait.Until(ExpectedConditions.StalenessOf(element));
        }

        protected void WaitForElementVisible(By locator)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void WaitForElementIsNotVisible(By locator)
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        protected void ClickButtonByName(string buttonName)
        {
            Driver.FindElement(By.CssSelector("button[name=" + buttonName + "]")).Click();
        }

        protected void GoBack()
        {
            Driver.Navigate().Back();
        }

    }
}
