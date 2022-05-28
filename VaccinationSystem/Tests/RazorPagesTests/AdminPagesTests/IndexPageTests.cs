//using VaccinationSystem.Data.Classes;
//using Xunit;
//using VaccinationSystem.Pages;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Security.Principal;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Http;
//using System.Threading;
//using System.Collections.Generic;
//using VaccinationSystem.Data;

//namespace Tests.RazorPagesTests
//{
//    public class IndexPageTests
//    {
//        [Fact]
//        public void Index_OnGetAsync_FilledName()
//        {
//            //arrange
//            var context = InMemoryDbContext.Get();
//            var userStore = InMemoryDbContext.TestUserStore<ApplicationUser>();
//            var userManager = InMemoryDbContext.TestUserManager(userStore);
//            var repo = new VaccinationSystem.Repositories.AdministratorRepository(context, userManager, userStore);
//            var pageModel = new AdminPanelModel(repo);

//            var claims = new List<Claim>()
//            {
//                new Claim(ClaimTypes.Name, "Test"),
//                new Claim(ClaimTypes.Role, Roles.Admin.Name),
//            };
//            var identity = new ClaimsIdentity(claims, "TestAuthType");
//            var claimsPrincipal = new ClaimsPrincipal(identity);
//            var pageContext = new PageContext
//            {
//                HttpContext = new DefaultHttpContext
//                {
//                    User = claimsPrincipal
//                }
//            };
//            pageModel.PageContext = pageContext;

//            //act
//            var result = pageModel.OnGetAsync();

//            //assert
//            Assert.True(identity.IsAuthenticated);
//            Assert.NotNull(pageModel);
//            Assert.Equal("Welcome Test", result.ViewData["Message"]);
//        }
//    }
//}
