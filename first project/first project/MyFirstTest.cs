using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace first_project
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
         //  ChromeOptions options = new ChromeOptions();
         //   options.AddArguments("start-fullscreen");

          //  driver = new ChromeDriver(options);
          //  wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            //FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\firefox.exe");
          //  IWebDriver driver = new FirefoxDriver( binary, new FirefoxProfile());


            // явное ожидание появления элемента
         //   WebdriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Name("q")));

        //    IList<IWebElement> links = (IList<IWebElement>)((IJavascriptExecutor)driver).ExecuteScript("return $$('a:contains((WebDriver)')");

        }

        [Test]
        public void TestMethod1()
        {
           // InternetExplorerOptions options = new InternetExplorerOptions();
          //  options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Dismiss;
          //  IWebDriver driver = new InternetExplorerDriver(options);

            // старая схема:
            //FirefoxOptions options = new FirefoxOptions();
           // options.UseLegacyImplementation = true;
           // driver = new FirefoxDriver(options);

            //FirefoxBinary binary = new FirefoxBinary(@"c:\Program Files (x86)\Nightly\firefox.exe");
           // IWebDriver driver = new FirefoxDriver(binary, new FirefoxProfile());

            driver.Url = "http://www.google.com/";
            driver.FindElement(By.Name("q")).SendKeys("webdriver");
            driver.FindElement(By.Name("btnG")).Click();
            wait.Until(ExpectedConditions.TitleIs("webdriver - Поиск в Google"));
        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
