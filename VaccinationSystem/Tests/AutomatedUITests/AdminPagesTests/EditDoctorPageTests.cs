using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using Xunit;

namespace Tests.AutomatedUITests.AdminPagesTests
{
    public class EditDoctorPageTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly EditDoctorPage _page;
        public EditDoctorPageTests()
        {
            _driver = new ChromeDriver();
            _page = new EditDoctorPage(_driver);
            _page.Navigate();
        }
        [Fact]
        public void Edit_WhenExecuted_ReturnsEditView()
        {
            Assert.Equal("Edit - VaccinationSystem", _page.Title);
            Assert.Contains("Doctor", _page.Source);
        }
        [Fact]
        public void Edit_WrongModelData_ReturnsErrorMessage()
        {
            _page.PopulateFirstName("");
            _page.PopulateLastName("");
            _page.PopulateEmail("");
            _page.ClickSave();
            Assert.Contains("The First name field is required.", _page.Source);
            Assert.Contains("The Last name field is required.", _page.Source);
            Assert.Contains("The Email field is required.", _page.Source);
        }
        [Fact]
        public void Edit_WrongEmailFormat_ReturnsErrorMessage()
        {
            _page.PopulateFirstName("New");
            _page.PopulateLastName("Doctor");
            _page.PopulateEmail("newtest doctor com");
            _page.ClickSave();
            Assert.Contains("The Email field is not a valid e-mail address.", _page.Source);
        }
        [Fact]
        public void Edit_WhenSuccessfullyExecuted_ReturnsIndexViewWithNewDoctor()
        {
            _page.PopulateFirstName("Edited");
            _page.PopulateLastName("Doctor");
            _page.PopulateEmail("edited@doctor.com");
            _page.ClickSave();
            Assert.Equal("Admin panel - VaccinationSystem", _page.Title);
            Assert.Contains("Edited Doctor", _page.Source);
            Assert.Contains("edited@doctor.com", _page.Source);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
