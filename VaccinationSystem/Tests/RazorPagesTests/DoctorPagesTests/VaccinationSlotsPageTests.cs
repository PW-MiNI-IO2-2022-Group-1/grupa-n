using VaccinationSystem.Data.Classes;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Pages.Doctor.VaccinationSlots;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using VaccinationSystem.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Identity;

namespace Tests.RazorPagesTests
{
    public class VaccinationSlotsPageTests
    {
        [Fact]
        public void AddVisit_OnPost_IfValidDate_Redirect()
        {
            //arrange
            var context = InMemoryDbContext.Get();
            var userStore = InMemoryDbContext.TestUserStore<ApplicationUser>();
            var userManager = InMemoryDbContext.TestUserManager(userStore);
            var repo = new VaccinationSystem.Repositories.DoctorRepository(context, 
                new VaccinationSystem.Repositories.VisitRepository(context));
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, "-2"),
                new Claim(ClaimTypes.Name, "doctor@localhost.com"),
                new Claim(ClaimTypes.Email, "doctor@localhost.com"),
                new Claim(new ClaimsIdentityOptions().SecurityStampClaimType, "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464"),
                new Claim(ClaimTypes.Role, Roles.Doctor.Name),
                new Claim("amr", "pwd"),
            };
            var identity = new ClaimsIdentity(claims, "Identity.Application");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var pageContext = new PageContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = claimsPrincipal
                }
            };
            var pageModel = new CreateModel(repo, userManager)
            {
                PageContext = pageContext
            };

            //act
            var hasher = new PasswordHasher<ApplicationUser>();
            pageModel.Doctor = new Doctor
            {
                Id = -2,
                FirstName = "Default",
                LastName = "Doctor",
                UserName = "doctor@localhost.com",
                NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                Email = "doctor@localhost.com",
                NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(new(), "doctor1"),
                EmailConfirmed = true,
                SecurityStamp = "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464",
                LicenceId = "-1",
            };
            //var usr3 =  userManager.GetUserAsync(claimsPrincipal).Result;

            pageModel.VisitDateTime = DateTime.Now.AddDays(1).AddMinutes(1);
            var result = pageModel.OnPostAsync();

            //assert
            Assert.IsType<RedirectToPageResult>(result.Result);
            RedirectToPageResult redirect = (RedirectToPageResult)result.Result;
            Assert.Equal("./Index", redirect.PageName);
        }
    }
}
