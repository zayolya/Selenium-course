using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace first_project
{
  /*  [TestFixture]
    public class OpenWindowTests : TestBase
    {
        [Test]
        public void OpenWindowTest()
        {
            LogintoAdminPanel();
            Driver.Url = "http://localhost:81/litecart/admin/?app=countries&doc=countries";
            FindAndClickLinkByText(" Add New Country");
            ReadOnlyCollection<IWebElement> allExternallinks = Driver.FindElements(By.XPath("//a/i[@class='fa fa-external-link']/.."));
            foreach (var link in allExternallinks)
            {
                string originalWindow = Driver.CurrentWindowHandle;
                List<string> existingWindows = Driver.WindowHandles.ToList();
                link.Click();
                string newWindow = Wait.Until(AnyWindowOtherThanExisting(existingWindows));
                Driver.SwitchTo().Window(newWindow);
                Driver.Close();
                Driver.SwitchTo().Window(originalWindow);
            }
        }
    }*/
}
