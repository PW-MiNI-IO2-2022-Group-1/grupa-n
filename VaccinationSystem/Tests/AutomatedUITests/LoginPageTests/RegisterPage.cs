using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

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
        private IWebElement CityElement => _driver.FindElement(By.Id("city-input"));
        private IWebElement ZipCodeElement => _driver.FindElement(By.Id("zipcode-input"));
        private IWebElement StreetElement => _driver.FindElement(By.Id("street-input"));
        private IWebElement HouseNumberElement => _driver.FindElement(By.Id("housenumber-input"));
        private IWebElement LocalNumberElement => _driver.FindElement(By.Id("localnumber-input"));
        private IWebElement RegisterElement => _driver.FindElement(By.Id("register-btn"));
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
        public void PopulateCity(string city) => CityElement.SendKeys(city);
        public void PopulateZipCode(string code) => ZipCodeElement.SendKeys(code);
        public void PopulateStreet(string street) => StreetElement.SendKeys(street);
        public void PopulateHouseNumber(string number) => HouseNumberElement.SendKeys(number);
        public void PopulateLocalNumber(string number) => LocalNumberElement.SendKeys(number);
        public void ClickRegister()
        {
            RegisterElement.Click();
        }
    }
}
