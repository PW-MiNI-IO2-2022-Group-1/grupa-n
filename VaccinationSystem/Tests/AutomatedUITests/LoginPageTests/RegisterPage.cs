using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.AutomatedUITests.LoginPageTests
{
    internal class RegisterPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:7072/Identity/Account/Register";
        private IWebElement FirstNameElement => _driver.FindElement(By.Id("firstname-input"));
        private IWebElement LastNameElement => _driver.FindElement(By.Id("lastname-input"));
        private IWebElement EmailElement => _driver.FindElement(By.Id("email-input"));
        private IWebElement PeselElement => _driver.FindElement(By.Id("pesel-input"));
        private IWebElement PasswordElement => _driver.FindElement(By.Id("password-input"));
        private IWebElement ConfirmPasswordElement => _driver.FindElement(By.Id("confirmpassword-input"));
        private IWebElement RegisterElement => _driver.FindElement(By.Id("registerSubmit"));
        public string Title => _driver.Title;
        public string Source => _driver.PageSource;
        public RegisterPage(IWebDriver driver) => _driver = driver;
        public void Navigate() => _driver.Navigate().GoToUrl(URI);
        public void PopulateFirstName(string name) => FirstNameElement.SendKeys(name);
        public void PopulateLastName(string name) => LastNameElement.SendKeys(name);
        public void PopulateEmail(string email) => EmailElement.SendKeys(email);
        public void PopulatePesel(string pesel) => PeselElement.SendKeys(pesel);
        public void PopulatePassword(string password) => PasswordElement.SendKeys(password);
        public void PopulateConfirmPassword(string password) => ConfirmPasswordElement.SendKeys(password);
        public void ClickRegister() => RegisterElement.Click();
    }
}
