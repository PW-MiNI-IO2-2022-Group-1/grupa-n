using OpenQA.Selenium;
using System;
using VaccinationSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Tests.AutomatedUITests.LoginPageTests;

namespace Tests.AutomatedUITests.AdminPagesTests
{
    public class AddDoctorPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:7072/Admin/Doctors/Add";
        private IWebElement FirstNameElement => _driver.FindElement(By.Id("firstname-input"));
        private IWebElement LastNameElement => _driver.FindElement(By.Id("lastname-input"));
        private IWebElement EmailElement => _driver.FindElement(By.Id("email-input"));
        private IWebElement PasswordElement => _driver.FindElement(By.Id("password-input"));
        private IWebElement ConfirmPasswordElement => _driver.FindElement(By.Id("confirmpassword-input"));
        private IWebElement SaveElement => _driver.FindElement(By.Id("save-btn"));
        public string Title => _driver.Title;
        public string Source => _driver.PageSource;
        public AddDoctorPage(IWebDriver driver) => _driver = driver;
        public void Navigate()
        {
            _driver.Navigate().GoToUrl(URI);
            if (Source.Contains("Login"))
            {
                LoginPage page = new LoginPage(_driver);
                page.LoginAdmin();
                _driver.Navigate().GoToUrl(URI);
            }
        }

        public void PopulateFirstName(string name) => FirstNameElement.SendKeys(name);
        public void PopulateLastName(string name) => LastNameElement.SendKeys(name);
        public void PopulateEmail(string email) => EmailElement.SendKeys(email);
        public void PopulatePassword(string password) => PasswordElement.SendKeys(password);
        public void PopulateConfirmPassword(string password) => ConfirmPasswordElement.SendKeys(password);
        public void ClickSave() => SaveElement.Click();
    }
}
