using VaccinationSystem.Data.Classes;
using Xunit;
using VaccinationSystem.Pages.AdminPanel.Doctors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Pages;

namespace Tests.RazorPagesTests
{
    public class DoctorsPageTests
    {
        [Fact]
        public void AddDoctor_OnPost_IfValidModel_Redirect()
        {
            //arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var pageModel = new AddModel(repo);

            //act
            pageModel.Doctor = new ApplicationUser
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
            };
            pageModel.Password = "Test11";
            var result = pageModel.OnPostAsync();

            //asserts
            Assert.IsType<RedirectToPageResult>(result.Result);
            RedirectToPageResult redirect = (RedirectToPageResult)result.Result;
            Assert.Equal("../Index", redirect.PageName);
        }

        [Fact]
        public void AddDoctor_OnPost_IfNotValidModel_ReturnPage()
        {
            //arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var pageModel = new AddModel(repo);

            //act
            pageModel.ModelState.AddModelError("Error", "Sample error description");
            var result = pageModel.OnPostAsync();

            //assert
            Assert.IsType<PageResult>(result.Result);
        }

        [Fact]
        public async void EditDoctor_OnPost_IfValidModel_Redirect()
        {
            //arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var pageModel = new EditModel(repo);

            //act
            pageModel.Doctor = new ApplicationUser
            {
                Id = -2,
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
        public void EditDoctor_OnPost_IfNotValidModel_ReturnPage()
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
        public void EditDoctor_OnGet_IfNotValidId_ReturnNotFound()
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
        public void DeleteDoctor_OnGet_IfNotValidId_ReturnNotFound()
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
