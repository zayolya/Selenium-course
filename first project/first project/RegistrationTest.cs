using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace first_project
{
    [TestFixture]
    public class RegistrationTest : TestBase
    {
        [Test]
        public void RegisterUserTest()
        {
            OpenHomePage();
            
            FindAndClickLinkByText("New customers click here");

            string testEmail = GetRandomAlphaNumeric() + "@test.test";
            
            FillRegistrationForm(testEmail);

            ClickCreateAccountButton();

            Logout();

            FillLoginForm(testEmail);

            ClickLoginButton();

            Logout();
        }

        private void ClickLoginButton()
        {
            _driver.FindElement(By.CssSelector("button[name=login]")).Click();
        }

        private void ClickCreateAccountButton()
        {
            _driver.FindElement(By.CssSelector("button[name=create_account]")).Click();
        }

        private void FillLoginForm(string testEmail)
        {
            FillInput(By.CssSelector("input[name=email]"), testEmail);
            FillInput(By.CssSelector("input[name=password]"), "123456");
        }

        private void FillRegistrationForm(string testEmail)
        {
            FillInput(By.CssSelector("input[name=firstname]"), "Test_name");
            FillInput(By.CssSelector("input[name=lastname]"), "Test_Last_name");
            FillInput(By.CssSelector("input[name=address1]"), "Test_addres1");
            FillInput(By.CssSelector("input[name=postcode]"), "A1A 1A1");
            FillInput(By.CssSelector("input[name=city]"), "Test_city");

            HiddenSelectOptionSelect(By.CssSelector("select[name=country_code]"), "CA");
            HiddenSelectOptionSelect(By.CssSelector("select[name=zone_code]"), "BC");

            FillInput(By.CssSelector("input[name=email]"), testEmail);
            FillInput(By.CssSelector("input[name=phone]"), "111111111");
            FillInput(By.CssSelector("input[name=password]"), "123456");
            FillInput(By.CssSelector("input[name=confirmed_password]"), "123456");
        }

        private string GetRandomAlphaNumeric()
        {
            Random random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(8).ToArray());
        }

        
    }
}
