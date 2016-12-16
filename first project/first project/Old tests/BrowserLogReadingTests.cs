using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace first_project
{
   /* [TestFixture]
    public class BrowserLogReadingTests : TestBase
    {
        [Test]
        public void ReadBrowserlog()
        {
            LogintoAdminPanel();
            Driver.Url = "http://localhost:81/litecart/admin/?app=catalog&doc=catalog&category_id=1";
            int linksCount = Driver.FindElements(By.CssSelector("table.dataTable tr.row td:nth-child(3) a")).Count;

            for (int i = 0; i < linksCount-3; i++)
            {
                IWebElement link = Driver.FindElement(By.CssSelector("table.dataTable tr:nth-child(" + (i + 5) + ") td:nth-child(3) a"));
                string itemName = link.Text;
                link.Click();
                
                Wait.Until(ExpectedConditions.TitleContains(itemName));
                ReadOnlyCollection<LogEntry> logs = Driver.Manage().Logs.GetLog("browser");
                Assert.IsTrue(logs.Count==0, "There are some browser errors on the page.");

                GoBack();
            }
        }
    }*/
}
