using VaccinationSystem.Data.Classes;
using Xunit;
using VaccinationSystem.Pages.AdminPanel.Patients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Pages;

namespace Tests.RazorPagesTests
{
    public class PatientsPageTests
    {
        [Fact]
        public void EditPatient_OnPost_IfValidModel_Redirect()
        {
            //arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var pageModel = new EditModel(repo);

            //act
            pageModel.Patient = new Patient
            {
                Id = -3,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
            };
            var result = pageModel.OnPostAsync();

            //assert
            Assert.IsType<RedirectToPageResult>(result.Result);
            RedirectToPageResult redirect = (RedirectToPageResult)result.Result;
            Assert.Equal("../Index", redirect.PageName);
        }

        [Fact]
        public void EditPatient_OnPost_IfNotValidModel_ReturnPage()
        {
            //arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var pageModel = new EditModel(repo);

            //act
            pageModel.ModelState.AddModelError("Error", "Sample error description");
            var result = pageModel.OnPostAsync();

            //assert
            Assert.IsType<PageResult>(result.Result);
        }

        [Fact]
        public void EditPatient_OnGet_IfNotValidId_ReturnNotFound()
        {
            //arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var pageModel = new EditModel(repo);

            //act
            var result = pageModel.OnGet(-1000);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void DeletePatient_OnGet_IfNotValidId_ReturnNotFound()
        {
            //arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var pageModel = new DeleteModel(repo);

            //act
            var result = pageModel.OnGet(-1000);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
