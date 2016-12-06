using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace first_project
{
    [TestFixture]
    public class AddItemsToCart : TestBase

    {
        [Test]
        public void TestMethod1()
        {
            OpenHomePage();
            int currentCartCount;
            for (int i = 0; i < 3; i++)
            {
                Driver.FindElements(By.CssSelector("div.content ul[class^=listing-wrapper] li a:not([class^=fancybox])"))[i].Click();
                IWebElement cartCountElement = Driver.FindElement(By.CssSelector("div#cart span.quantity"));
                currentCartCount = Int32.Parse(cartCountElement.Text);
                if (IsElementPresent(By.Name("options[Size]")))
                {
                    SelectOptionSelect(By.Name("options[Size]"), 1);
                }
                ClickButtonByName("add_cart_product");
                Wait.Until(ExpectedConditions.TextToBePresentInElement(cartCountElement,
                    (currentCartCount + 1).ToString()));
                GoBack();
                Wait.Until(ExpectedConditions.UrlMatches("http://localhost:81/litecart/en/"));
            }
            
            FindAndClickLinkByText("Checkout »");
            
            ReadOnlyCollection<IWebElement> cartTableRows = Driver.FindElements(By.XPath("//div[@id='order_confirmation-wrapper']//table//tr/td[@class='item']/.."));
            List<string> itemsNames = new List<string>();
            
            foreach (var row in cartTableRows)
            {
                itemsNames.Add(row.FindElement(By.CssSelector("td.item")).Text);
            }

            for (int i = 0; i < itemsNames.Count; i++)
            {
                IWebElement tableRow = Driver.FindElement(By.XPath("//div[@id='order_confirmation-wrapper']//table//tr/td[@class='item'][contains(.,'" + itemsNames[i] + "')]"));
                if (i < itemsNames.Count-1) Driver.FindElements(By.CssSelector("ul.shortcuts li.shortcut a"))[0].Click();
                IWebElement itemsName = Driver.FindElement(By.CssSelector("form[name=cart_form] strong"));
                Wait.Until(
                    ExpectedConditions.TextToBePresentInElement(itemsName, itemsNames[i]));
                ClickButtonByName("remove_cart_item");
                Wait.Until(ExpectedConditions.StalenessOf(itemsName));
                Wait.Until(ExpectedConditions.StalenessOf(tableRow));
            }
        }
    }
}
