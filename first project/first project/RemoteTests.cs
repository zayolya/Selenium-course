using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace first_project
{
    [TestFixture]
    public class RemoteTests
    {
        private IWebDriver _remoteDriver;
        private WebDriverWait _wait;
        [SetUp]
        public void Start()
        {
             _remoteDriver = new RemoteWebDriver(new Uri("http://192.168.21.98:4444/wd/hub"), DesiredCapabilities.Chrome());
             _wait = new WebDriverWait(_remoteDriver, TimeSpan.FromSeconds(10));
             _remoteDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }


        [Test]
        public void RemoteTest1()
        {
            _remoteDriver.Url = "https://www.google.ru/";
        }

        [TearDown]
        public void Stop()
        {
            _remoteDriver.Quit();
            _remoteDriver = null;
        }
    }
}
