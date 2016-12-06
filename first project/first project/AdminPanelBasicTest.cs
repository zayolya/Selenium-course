using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace first_project
{
    [TestFixture]
    public class AdminPanelBasicTest : TestBase
    {
        [Test]
        public void AdminPanelBasicTest1()
        {
            LogintoAdminPanel();
            
            SelectMenuItem("Appearence");
            CheckPageTitle("Template | My Store");

            SelectMenuItem("Catalog");
            CheckPageTitle("Catalog | My Store");

            SelectMenuItem("Countries");
            CheckPageTitle("Countries | My Store");

            SelectMenuItem("Currencies");
            CheckPageTitle("Currencies | My Store");

            SelectMenuItem("Customers");
            CheckPageTitle("Customers | My Store");

            SelectMenuItem("Geo Zones");
            CheckPageTitle("Geo Zones | My Store");

            SelectMenuItem("Languages");
            CheckPageTitle("Languages | My Store");

            SelectMenuItem("Modules");
            CheckPageTitle("Job Modules | My Store");

            SelectMenuItem("Orders");
            CheckPageTitle("Orders | My Store");

            SelectMenuItem("Pages");
            CheckPageTitle("Pages | My Store");

            SelectMenuItem("Reports");
            CheckPageTitle("Monthly Sales | My Store");

            SelectMenuItem("Settings");
            CheckPageTitle("Settings | My Store");

            SelectMenuItem("Slides");
            CheckPageTitle("Slides | My Store");

            SelectMenuItem("Tax");
            CheckPageTitle("Tax Classes | My Store");

            SelectMenuItem("Translations");
            CheckPageTitle("Search Translations | My Store");

            SelectMenuItem("Users");
            CheckPageTitle("Users | My Store");

            SelectMenuItem("vQmods");
            CheckPageTitle("vQmods | My Store");
        }

        private void SelectMenuItem(string itemName)
        {
            Driver.FindElement(By.XPath("//div[@id='box-apps-menu-wrapper']//span[contains(.,'" + itemName + "')]")).Click();
        }
        
        private void CheckPageTitle(string title)
        {
            Wait.Until(ExpectedConditions.TitleIs(title));
        }
    }
}
