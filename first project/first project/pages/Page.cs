using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace first_project.pages
{
    internal class Page
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public IWebElement WaitForElement(By locator)
        {
            return wait.Until(d => d.FindElement(locator));
        }

        public IWebElement WaitForElementExists(By locator)
        {
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }
        public void WaitForElementDisappear(IWebElement element)
        {
            driver.Navigate().Refresh();
            wait.Until(ExpectedConditions.StalenessOf(element));
        }

        public void WaitForElementVisible(By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForElementIsNotVisible(By locator)
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        public void SelectOptionSelect(IWebElement select, int selectIndex)
        {
            SelectElement selectElement = new SelectElement(select);
            selectElement.SelectByIndex(selectIndex);
        }
        public void ClickButtonByName(string buttonName)
        {
            driver.FindElement(By.CssSelector("button[name=" + buttonName + "]")).Click();
        }
        public void FindAndClickLinkByText(string linkText)
        {
            driver.FindElement(By.XPath("//a[contains(.,'" + linkText + "')]")).Click();
        }
        public void CheckStalenessOfElement(IWebElement element)
        {
            wait.Until(ExpectedConditions.StalenessOf(element));
        }
    }
}
