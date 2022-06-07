using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Tests.AutomatedUITests.LoginPageTests
{
    public class RegisterPageTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly RegisterPage _page;
        public RegisterPageTests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _page = new RegisterPage(_driver);
            _page.Navigate();
        }
        [Fact]
        public void Register_WhenExecuted_ReturnsRegisterView()
        {
            Assert.Equal("Register - VaccinationSystem", _page.Title);
            Assert.Contains("Create a new account.", _page.Source);
        }
        [Fact]
        public void Register_WrongModelData_ReturnsErrorMessage()
        {
            _page.ClickRegister();
            Assert.Contains("The First name field is required.", _page.Source);
            Assert.Contains("The Last name field is required.", _page.Source);
            Assert.Contains("The Pesel field is required.", _page.Source);
            Assert.Contains("The Email field is required.", _page.Source);
            Assert.Contains("The Password field is required.", _page.Source);
        }
        [Fact]
        public void Register_WhenSuccessfullyExecuted_ReturnsConfirmMail()
        {
            _page.PopulateFirstName("New Test");
            _page.PopulateLastName("Patient");
            _page.PopulatePesel("99112233445");
            _page.PopulateEmail("newtest@patient.com");
            _page.PopulatePassword("newtest1");
            _page.PopulateConfirmPassword("newtest1");
            _page.PopulateCity("city");
            _page.PopulateZipCode("22-100");
            _page.PopulateStreet("street");
            _page.PopulateHouseNumber("5A");
            _page.PopulateLocalNumber("7");
            _page.ClickRegister();
            Assert.Equal("Register - VaccinationSystem", _page.Title);
            Assert.Contains("Register confirmation", _page.Source);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
