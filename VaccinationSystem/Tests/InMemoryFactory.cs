using API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;

namespace Tests
{
    public static class InMemoryFactory
    {
        private static readonly DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = 
                                    new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("InMemoryDb");

        public static VaccinationSystem.Repositories.AdministratorRepository
            GetAdministratorRepository(ApplicationDbContext dbContext)
        {
            var userStore = TestUserStore<ApplicationUser>();
            var userManager = TestUserManager(userStore);
            return new VaccinationSystem.Repositories.AdministratorRepository(dbContext, userManager, userStore);
        }

        public static UserService GetUserService()
        {
            var userStore = TestUserStore<ApplicationUser>();
            var userManager = TestUserManager(userStore);
            var signInManager = new Mock<SignInManager<ApplicationUser>>(
                userManager,
                /* IHttpContextAccessor contextAccessor */Mock.Of<IHttpContextAccessor>(),
                /* IUserClaimsPrincipalFactory<TUser> claimsFactory */Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
                /* IOptions<IdentityOptions> optionsAccessor */null,
                /* ILogger<SignInManager<TUser>> logger */null,
                /* IAuthenticationSchemeProvider schemes */null,
                /* IUserConfirmation<TUser> confirmation */null).Object;

            // jwt nie moze byc mockowany
            return new UserService(signInManager, userManager, new Mock<IJwtHelper>().Object);
        }

        public static ApplicationDbContext GetDbContext()
        {
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            // EnsureCreated uruchomi seeding
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        private static UserManager<TUser> TestUserManager<TUser>(IUserStore<TUser> store) where TUser : class
        {
            var options = new Mock<IOptions<IdentityOptions>>();
            var idOptions = new IdentityOptions();
            idOptions.Lockout.AllowedForNewUsers = false;
            options.Setup(o => o.Value).Returns(idOptions);
            var userValidators = new List<IUserValidator<TUser>>();
            var validator = new Mock<IUserValidator<TUser>>();
            userValidators.Add(validator.Object);
            var pwdValidators = new List<PasswordValidator<TUser>>();
            pwdValidators.Add(new PasswordValidator<TUser>());
            var userManager = new UserManager<TUser>(store, options.Object, new PasswordHasher<TUser>(),
                userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null,
                new Mock<ILogger<UserManager<TUser>>>().Object);
            validator.Setup(v => v.ValidateAsync(userManager, It.IsAny<TUser>()))
                .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();
            return userManager;
        }

        private static IUserStore<TUser> TestUserStore<TUser>() where TUser: class
        {
            return new Mock<IUserStore<TUser>>().Object;
        }
    }
}
