using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace first_project.pages
{
    internal class ItemPage : Page
    {
        public ItemPage(IWebDriver driver) : base(driver) { }


        [FindsBy(How = How.CssSelector, Using = "div#cart span.quantity")]
        internal IWebElement CartCount;

        internal void SelectSize()
        {
            ReadOnlyCollection<IWebElement> sizeSelect = driver.FindElements(By.Name("options[Size]"));
            if (sizeSelect.Count>0)
            {
                SelectOptionSelect(sizeSelect[0], 1);
            }
        }

        internal void AddToCart()
        {
            int currentCartCount = Int32.Parse(driver.FindElement(By.CssSelector("div#cart span.quantity")).Text);
            SelectSize();
            ClickButtonByName("add_cart_product");
            wait.Until(ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.CssSelector("div#cart span.quantity")), (currentCartCount + 1).ToString()));
        }

        internal void CheckOut()
        {
            FindAndClickLinkByText("Checkout »");
        }

    }
}
