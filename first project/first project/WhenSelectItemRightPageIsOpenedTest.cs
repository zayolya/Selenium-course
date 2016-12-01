using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace first_project
{
    [TestFixture]
    public class WhenSelectItemRightPageIsOpenedTest : TestBase
    {
        [Test]
        public void IpemsPageOpensCorrectlyTest()
        {
            OpenHomePage();
            IWebElement itemLink = _driver.FindElement(By.CssSelector("div#box-campaigns div.content ul li:first-child a:not([class^=fancybox])"));
            
            string itemName = itemLink.FindElement(By.CssSelector("div.name")).Text;
            
            IWebElement regularPrice = itemLink.FindElement(By.CssSelector("s.regular-price"));
            IWebElement campaignPrice = itemLink.FindElement(By.CssSelector("strong.campaign-price"));

            CheckPricesStyles(regularPrice, campaignPrice, "rgba(119, 119, 119, 1)");

            string regularPriceText = regularPrice.Text;
            string campaignPriceText = campaignPrice.Text;

            itemLink.Click();

            IWebElement regularPriceItem =
                _driver.FindElement(By.CssSelector("div.content div.information div.price-wrapper s.regular-price"));
            IWebElement campaignPriceItem =
                _driver.FindElement(By.CssSelector("div.content div.information div.price-wrapper strong.campaign-price"));

            CheckPricesStyles(regularPriceItem, campaignPriceItem, "rgba(102, 102, 102, 1)");

            Assert.AreEqual(itemName, _driver.FindElement(By.CssSelector("div#box-product h1.title")).Text, "Name doesn't match");
            Assert.AreEqual(regularPriceText, regularPriceItem.Text, "Regular price doesn't match");
            Assert.AreEqual(campaignPriceText, campaignPriceItem.Text, "Campaign price doesn't match");
        }

        private void CheckPricesStyles(IWebElement regPrice, IWebElement campPrice, string color)
        {
            Assert.AreEqual(color, regPrice.GetCssValue("color"), "Color doesn't match");
            Assert.AreEqual("line-through", regPrice.GetCssValue("text-decoration"), "Text-decoration doesn't match");
            Assert.AreEqual("rgba(204, 0, 0, 1)", campPrice.GetCssValue("color"), "Color doesn't match");
            Assert.AreEqual("bold", campPrice.GetCssValue("font-weight"), "Font-weight doesn't match");
            
            String regFontSize = regPrice.GetCssValue("font-size");
            regFontSize = regFontSize.Remove(regFontSize.IndexOf('p')).Replace(".", ",");
            
            String campFontSize = campPrice.GetCssValue("font-size");
            campFontSize = campFontSize.Remove(campFontSize.IndexOf('p')).Replace(".", ",");
            
            Assert.IsTrue(Convert.ToDouble(regFontSize)< Convert.ToDouble(campFontSize), "Font sizes are wrong");
        }
    }
}
