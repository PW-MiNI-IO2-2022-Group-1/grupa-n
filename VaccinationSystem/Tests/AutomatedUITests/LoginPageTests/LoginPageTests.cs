using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using Xunit;

namespace Tests.AutomatedUITests.LoginPageTests
{
    public class LoginPageTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _page;
        public LoginPageTests()
        {
            _driver = new ChromeDriver();
            _page = new LoginPage(_driver);
            _page.Navigate();
        }
        [Fact]
        public void Login_WhenExecuted_ReturnsLoginView()
        {
            Assert.Equal("Log in - VaccinationSystem", _page.Title);
            Assert.Contains("Use a local account to log in.", _page.Source);
        }
        [Fact]
        public void Login_WrongModelData_ReturnsErrorMessage()
        {
            _page.ClickLogin();
            Assert.Contains("The Email field is required.", _page.Source);
            Assert.Contains("The Password field is required.", _page.Source);
        }
        [Fact]
        public void Login_WhenSuccessfullyExecuted_ReturnsIndexViewWithNewEmployee()
        {
            _page.PopulateEmail("admin@localhost.com");
            _page.PopulatePassword("admin1");
            _page.ClickLogin();
            Assert.Equal("Home page - VaccinationSystem", _page.Title);
            Assert.Contains("Hello", _page.Source);
            Assert.Contains("Admin panel", _page.Source);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
