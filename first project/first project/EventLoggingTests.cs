using System;
using System.Drawing.Imaging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace first_project
{
    [TestFixture]
    public class EventLoggingTests
    {
        private EventFiringWebDriver _driver;
        private WebDriverWait _wait;
        [SetUp]
        public void Start()
        {
            _driver = new EventFiringWebDriver(new ChromeDriver());
            
            _driver.FindingElement += (sender, e) => Console.WriteLine(e.FindMethod);
            _driver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + " found");
            _driver.ExceptionThrown += (sender, e) => Console.WriteLine(e.ThrownException);
            
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
        [Test]
        public void TestMethod1()
        {
            _driver.Url = "http://www.google.com";
            IWebElement query = _driver.FindElement(By.Name("q"));
            query.SendKeys("test");
            _driver.GetScreenshot().SaveAsFile("screen.png", ImageFormat.Png);
            query.Submit();
            _wait.Until(ExpectedConditions.TitleContains("test"));
        }
        [TearDown]
        public void Stop()
        {
            _driver.Quit();
            _driver = null;
        }
      }
}
