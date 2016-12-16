using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using first_project.model;
using first_project.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace first_project.app
{
    public class Application
    {
        private IWebDriver driver;

        private RegistrationPage registrationPage;
        private AdminPanelLoginPage adminPanelLoginPage;
        private CustomerListPage customerListPage;
        private HomePage homePage;
        private ItemPage itemPage;
        private CheckOutPage checkOutPage;

        public Application()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            registrationPage = new RegistrationPage(driver);
            adminPanelLoginPage = new AdminPanelLoginPage(driver);
            customerListPage = new CustomerListPage(driver);
            homePage = new HomePage(driver);
            
            
        }

        public void Quit()
        {
            driver.Quit();
        }

        internal void RegisterNewCustomer(Customer customer)
        {
            homePage.Open();
            homePage.NewCustomersClickHere.Click();

            registrationPage.FirstnameInput.SendKeys(customer.Firstname);
            registrationPage.LastnameInput.SendKeys(customer.Lastname);
            registrationPage.Address1Input.SendKeys(customer.Address);
            registrationPage.PostcodeInput.SendKeys(customer.Postcode);
            registrationPage.CityInput.SendKeys(customer.City);
            registrationPage.SelectCountry(customer.Country);
            registrationPage.SelectZone(customer.Zone);
            registrationPage.EmailInput.SendKeys(customer.Email);
            registrationPage.PhoneInput.SendKeys(customer.Phone);
            registrationPage.PasswordInput.SendKeys(customer.Password);
            registrationPage.ConfirmedPasswordInput.SendKeys(customer.Password);
            registrationPage.CreateAccountButton.Click();
        }

        internal ISet<string> GetCustomerIds()
        {
            if (adminPanelLoginPage.Open().IsOnThisPage())
            {
                adminPanelLoginPage.EnterUsername("admin").EnterPassword("admin").SubmitLogin();
            }

            return customerListPage.Open().GetCustomerIds();
        }

        public void Login(Customer customer)
        {
            homePage.EmailInput.SendKeys(customer.Email);
            homePage.PasswordInput.SendKeys(customer.Password);
            homePage.SubmitLogin();
            
        }


        public void OpenItem(int i)
        {
            var items = homePage.Items();
            items[i].Click();
            itemPage = new ItemPage(driver);
        }

        public void LogintoAdminPanel()
        {
            if (adminPanelLoginPage.Open().IsOnThisPage())
            {
                adminPanelLoginPage.EnterUsername("admin").EnterPassword("admin").SubmitLogin();
            }
        }

        public void OpenHomePage()
        {
            homePage.Open();
        }

        public void FillInput(By locator, string inputValue)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(inputValue);
        }

        public void HiddenSelectOptionSelect(By locator, string value)
        {
            IWebElement select = driver.FindElement(locator);
            driver.ExecuteJavaScript("arguments[0].style.opacity=1;", select);
            SelectElement selectElement = new SelectElement(select);
            selectElement.SelectByValue(value);
        }

        

        public void Logout()
        {
            homePage.Logout.Click();
        }

        public void Unhide(IWebElement element)
        {
            String script = "arguments[0].style.opacity=1;"
                            + "arguments[0].style['transform']='translate(0px, 0px) scale(1)';"
                            + "arguments[0].style['MozTransform']='translate(0px, 0px) scale(1)';"
                            + "arguments[0].style['WebkitTransform']='translate(0px, 0px) scale(1)';"
                            + "arguments[0].style['msTransform']='translate(0px, 0px) scale(1)';"
                            + "arguments[0].style['OTransform']='translate(0px, 0px) scale(1)';"
                            + "return true;";
            driver.ExecuteJavaScript(script, element);
        }

        public void SetDatepicker(string cssSelector, string date)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until<bool>(
                d => driver.FindElement(By.CssSelector(cssSelector)).Displayed);
            (driver as IJavaScriptExecutor).ExecuteScript(
                String.Format("$('{0}').datepicker('setDate', '{1}')", cssSelector, date));
        }

       

        public void UploadFile(By locator, string filePath)
        {
            IWebElement fileUpload = driver.FindElement(locator);
            Unhide(fileUpload);
            fileUpload.SendKeys(filePath);
        }

       public bool IsElementPresent(By locator)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
                return driver.FindElements(locator).Count > 0;
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
            }
        }

        public bool IsElementNotPresent(By locator)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
                return driver.FindElements(locator).Count == 0;
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            }
        }


        public void GoBack()
        {
            driver.Navigate().Back();
        }

        public Func<IWebDriver, string> AnyWindowOtherThanExisting(List<string> oldWindows)
        {
            return (Func<IWebDriver, string>)(driver =>
            {
                List<string> allhandles = driver.WindowHandles.ToList();
                foreach (var window in oldWindows)
                {
                    allhandles.Remove(window);
                }
                return allhandles.Count > 0 ? allhandles[0] : null;
            });
        }

        public void AddItemToCart()
        {
           itemPage.AddToCart();
        }

        public void CheckOut()
        {
           itemPage.CheckOut();
           checkOutPage = new CheckOutPage(driver);
        }

        public List<string> getItemsNames()
        {
            ReadOnlyCollection<IWebElement> cartTableRows = checkOutPage.ItemsRows();
            
            List<string> itemsNames = new List<string>();

            foreach (var row in cartTableRows)
            {
                itemsNames.Add(row.FindElement(By.CssSelector("td.item")).Text);
            }
            return itemsNames;
        }

        public IWebElement GetRow(string itemsName)
        {
           return checkOutPage.TableRow(itemsName);
        }

        public void ClickShortCut()
        {
            checkOutPage.ShortCuts()[0].Click();
        }

        public void RemoveItem(string itemsName)
        {
            checkOutPage.RemoveItem(itemsName);
        }

        public void CheckStalenessOfElement(IWebElement element)
        {
            checkOutPage.CheckStalenessOfElement(element);
        }
    }
}
