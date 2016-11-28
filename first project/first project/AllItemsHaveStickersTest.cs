using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace first_project
{
    [TestClass]
    public class AllItemsHaveStickersTest : TestBase 
    {
        [Test]
        public void TestMethod1()
        {
            _driver.Url = "http://localhost:81/litecart/";
            ReadOnlyCollection<IWebElement> items = _driver.FindElements(By.XPath("//div[@class='content']//ul[@class='listing-wrapper products']//li"));
            foreach (var item in items)
            {
                ReadOnlyCollection<IWebElement> stickers = item.FindElements(By.CssSelector("div[class^='sticker']"));
                Assert.AreEqual(1,stickers.Count);
            }
           
        }
    }
}
