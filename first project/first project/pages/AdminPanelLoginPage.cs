﻿using OpenQA.Selenium;

namespace first_project.pages
{
    internal class AdminPanelLoginPage : Page
    {
        public AdminPanelLoginPage(IWebDriver driver) : base(driver) { }

        internal AdminPanelLoginPage Open()
        {
            driver.Url = "http://localhost:81/litecart/admin";
            return this;
        }

        internal bool IsOnThisPage()
        {
            return driver.FindElements(By.Id("box-login")).Count > 0;
        }

        internal AdminPanelLoginPage EnterUsername(string username)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
            return this;
        }

        internal AdminPanelLoginPage EnterPassword(string password)
        {
            driver.FindElement(By.Name("password")).SendKeys(password);
            return this;
        }

        internal void SubmitLogin()
        {
            driver.FindElement(By.Name("login")).Click();
            wait.Until(d => d.FindElement(By.Id("box-apps-menu")));
        }

    }
}
