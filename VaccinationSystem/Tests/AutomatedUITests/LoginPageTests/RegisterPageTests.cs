using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
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
            Assert.Contains("The First Name field is required.", _page.Source);
            Assert.Contains("The Last Name field is required.", _page.Source);
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
            _page.ClickRegister();
            Assert.Equal("Home page - VaccinationSystem", _page.Title);
            Assert.Contains("Hello", _page.Source);
            Assert.Contains("Patient panel", _page.Source);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
