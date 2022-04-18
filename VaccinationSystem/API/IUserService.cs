using API;
using VaccinationSystem.Data.Classes;

namespace API
{
    public interface IUserService
    {
        Task<bool> HasValidCredentialsAsync(RequestModels.Login loginInfo);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IList<string>> GetRolesForUser(ApplicationUser user);
        public string GetTokenForUser(string email, string role, int? id = null);
    }
}
