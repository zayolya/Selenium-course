using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace first_project.pages
{
    internal class CheckOutPage : Page
    {
        public CheckOutPage(IWebDriver driver) : base(driver) { }

        internal ReadOnlyCollection<IWebElement> ItemsRows()
        {
            return
                driver.FindElements(By.XPath("//div[@id='order_confirmation-wrapper']//table//tr/td[@class='item']/.."));
        }

        internal ReadOnlyCollection<IWebElement> ShortCuts()
        {
            return driver.FindElements(By.CssSelector("ul.shortcuts li.shortcut a"));
        }

        [FindsBy(How = How.CssSelector, Using = "form[name=cart_form] strong")]
        internal IWebElement ItemsName;


        internal IWebElement TableRow(string itemName )
        {
            return driver.FindElement(By.XPath("//div[@id='order_confirmation-wrapper']//table//tr/td[@class='item'][contains(.,'" + itemName + "')]"));
        }

        internal void RemoveItem(string itemsName)
        {
            IWebElement currentName = driver.FindElement(By.CssSelector("form[name=cart_form] strong"));
            wait.Until(
                ExpectedConditions.TextToBePresentInElement(currentName, itemsName));
            ClickButtonByName("remove_cart_item");
            wait.Until(ExpectedConditions.StalenessOf(currentName));
        }

        
    }
}
