using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.AutomatedUITests.LoginPageTests
{
    internal class LoginPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:7072/Identity/Account/Login";
        private IWebElement EmailElement => _driver.FindElement(By.Id("email-input"));
        private IWebElement PasswordElement => _driver.FindElement(By.Id("password-input"));
        private IWebElement LoginElement => _driver.FindElement(By.Id("login-submit"));
        public string Title => _driver.Title;
        public string Source => _driver.PageSource;
        public LoginPage(IWebDriver driver) => _driver = driver;
        public void Navigate() => _driver.Navigate().GoToUrl(URI);
        public void PopulateEmail(string email) => EmailElement.SendKeys(email);
        public void PopulatePassword(string password) => PasswordElement.SendKeys(password);
        public void ClickLogin() => LoginElement.Click();
        public void LoginAdmin()
        {
            PopulateEmail("admin@localhost.com");
            PopulatePassword("admin1");
            ClickLogin();
        }
    }
}
