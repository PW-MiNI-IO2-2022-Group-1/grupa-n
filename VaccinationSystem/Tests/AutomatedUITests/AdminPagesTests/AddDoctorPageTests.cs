using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using Xunit;

namespace Tests.AutomatedUITests.AdminPagesTests
{
    public class AddDoctorPageTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly AddDoctorPage _page;
        public AddDoctorPageTests()
        {
            _driver = new ChromeDriver();
            _page = new AddDoctorPage(_driver);
            _page.Navigate();
        }

        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            Assert.Equal("Add - VaccinationSystem", _page.Title);
            Assert.Contains("Doctor", _page.Source);
        }

        [Fact]
        public void Create_WrongModelData_ReturnsErrorMessage()
        {
            _page.ClickSave();
            Assert.Contains("The First name field is required.", _page.Source);
            Assert.Contains("The Last name field is required.", _page.Source);
            Assert.Contains("The Email field is required.", _page.Source);
            Assert.Contains("The Password field is required.", _page.Source);
            Assert.Contains("The Confirm password field is required.", _page.Source);
        }

        [Fact]
        public void Create_WrongEmailFormat_ReturnsErrorMessage()
        {
            _page.PopulateFirstName("New");
            _page.PopulateLastName("Doctor");
            _page.PopulateEmail("newtest doctor com");
            _page.PopulatePassword("testpass1");
            _page.PopulateConfirmPassword("testpass1");
            _page.ClickSave();
            Assert.Contains("The Email field is not a valid e-mail address.", _page.Source);
        }

        [Fact]
        public void Create_WhenSuccessfullyExecuted_ReturnsAdminPanelPageWithNewDoctor()
        {
            _page.PopulateFirstName("New");
            _page.PopulateLastName("Doctor");
            _page.PopulateEmail("newtest@doctor.com");
            _page.PopulatePassword("testpass1");
            _page.PopulateConfirmPassword("testpass1");
            _page.ClickSave();
            Assert.Equal("Admin panel - VaccinationSystem", _page.Title);
            Assert.Contains("New Doctor", _page.Source);
            Assert.Contains("newtest@doctor.com", _page.Source);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
