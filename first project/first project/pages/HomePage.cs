using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace first_project.pages
{
    internal class HomePage : Page
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        internal void Open()
        {
            driver.Url = "http://localhost:81/litecart/en/";
        }
        
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'New customers click here')]")]
        internal IWebElement NewCustomersClickHere;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Logout')]")]
        internal IWebElement Logout;

        [FindsBy(How = How.CssSelector, Using = "input[name=email]")]
        internal IWebElement EmailInput;

        [FindsBy(How = How.CssSelector, Using = "input[name=password]")]
        internal IWebElement PasswordInput;

        internal ReadOnlyCollection<IWebElement> Items()
        {
            return
                driver.FindElements(By.CssSelector("div.content ul[class^=listing-wrapper] li a:not([class^=fancybox])"));
        }

        internal void SubmitLogin()
        {
            driver.FindElement(By.CssSelector("button[name=login]")).Click();
           // wait.Until(d => d.FindElement(By.Id("box-apps-menu")));
        }
    }
}
