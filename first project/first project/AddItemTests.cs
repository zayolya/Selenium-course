using NUnit.Framework;
using OpenQA.Selenium;

namespace first_project
{
    [TestFixture]
    public class AddItemTests : TestBase
    {
        [Test]
        public void AddItemTest()
        {
            LogintoAdminPanel();
            _driver.Url = "http://localhost:81/litecart/admin/?app=catalog&doc=catalog";

            FindAndClickLinkByText("Add New Product");

            //General tab
            
            string itemName = "Test_name";
            FillInput(By.CssSelector("input[name=name\\[en\\]]"), itemName);
            FillInput(By.CssSelector("input[name=code]"), "code_test");
            _driver.FindElements(By.CssSelector("input[type=checkbox][name^=categories]"))[1].Click();
            HiddenSelectOptionSelect(By.Name("default_category_id"), "1");
            _driver.FindElements(By.CssSelector("input[type=checkbox][name^=product_groups]"))[1].Click();
            FillInput(By.CssSelector("input[name=quantity]"), "1");

            UploadFile(By.Name("new_images[]"), @"C:\Users\olgaz\Desktop\new.JPG");

            _driver.FindElement((By.CssSelector("input[name=date_valid_from]"))).SendKeys("02/20/2016");
            _driver.FindElement((By.CssSelector("input[name=date_valid_to]"))).SendKeys("02/28/2016");
            
            FindAndClickLinkByText("Information");
            
            //Information tab
            
            HiddenSelectOptionSelect(By.Name("manufacturer_id"), "1");
            FillInput(By.Name("keywords"), "key_word");
            FillInput(By.Name("short_description[en]"), "short description");
            FillInput(By.Name("description[en]"), "full description");
            FillInput(By.Name("head_title[en]"), "head_title");
            FillInput(By.Name("meta_description[en]"), "meta_description");

            FindAndClickLinkByText("Prices");

            //Prices tab

            FillInput(By.Name("purchase_price"), "2.00");
            HiddenSelectOptionSelect(By.Name("purchase_price_currency_code"), "USD");
            FillInput(By.Name("gross_prices[USD]"), "2.00");
           
            _driver.FindElement(By.Name("save")).Click();

            Assert.IsTrue(_driver.FindElements(By.XPath("//table[@class='dataTable']//a[contains(.,'" + itemName + "')]")).Count>0);
        }
    }
}
