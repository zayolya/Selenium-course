using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace first_project
{
  /*  [TestFixture]
    public class ProxyTests
    {
        [Test]
        public void TestMethod1()
        {
            Proxy proxy = new Proxy();
            proxy.Kind = ProxyKind.Manual;
            proxy.HttpProxy = "localhost:8888";
            ChromeOptions options = new ChromeOptions();
            options.Proxy = proxy;
            IWebDriver driver = new ChromeDriver(options);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            
           
            driver.Navigate().GoToUrl("https://www.google.ru/");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("test");
            query.Submit();
            wait.Until(ExpectedConditions.TitleContains("test"));
           


            driver.Quit();
        }
    }*/
}
