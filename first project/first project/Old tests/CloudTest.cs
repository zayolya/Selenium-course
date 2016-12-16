using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace first_project
{
  /*  [TestFixture]
   public class CloudTest
    {
        [Test]
        public void CloudTest1()
        {
            IWebDriver driver;
            DesiredCapabilities capability = DesiredCapabilities.Chrome();
            capability.SetCapability("browserstack.user", "olgasavinova1");
            capability.SetCapability("browserstack.key", "CQGzWqd4Cdcs6oFJx3FP");

            driver = new RemoteWebDriver(
              new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
            driver.Navigate().GoToUrl("http://www.google.com");
            Console.WriteLine(driver.Title);

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Browserstack");
            query.Submit();
            Console.WriteLine(driver.Title);

            driver.Quit();
        }
    }*/
}