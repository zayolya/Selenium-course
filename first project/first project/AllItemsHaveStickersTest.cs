using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace first_project
{
    [TestFixture]
    public class AllItemsHaveStickersTest : TestBase 
    {
        [Test]
        public void TestMethod1()
        {
            OpenHomePage();
            ReadOnlyCollection<IWebElement> items = _driver.FindElements(By.XPath("//div[@class='content']//ul[@class='listing-wrapper products']//li"));
            foreach (var item in items)
            {
                ReadOnlyCollection<IWebElement> stickers = item.FindElements(By.CssSelector("div[class^='sticker']"));
                Assert.AreEqual(1,stickers.Count);
            }
           
        }
    }
}
