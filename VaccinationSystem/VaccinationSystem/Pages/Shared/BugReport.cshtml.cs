using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;
using VaccinationSystem.Validations;


namespace VaccinationSystem.Pages
{
    public class BugReportModel : PageModel
    {
        private readonly IBugReportRepository _bugReportRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public BugReportModel(IBugReportRepository bugReportRepository, UserManager<ApplicationUser> userManager)
        {
            _bugReportRepository = bugReportRepository;
            _userManager = userManager;
        }
        [BindProperty]
        public BugReport BugReport { get; set; }
        public Data.Classes.ApplicationUser ApplicationUser { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ApplicationUser = (Data.Classes.ApplicationUser)await _userManager.GetUserAsync(User);
            BugReport.User = ApplicationUser;
            BugReport.Origin = BugReportOrigin.Written;
            BugReport.Date = DateTime.Now;
            if(BugReport.Description!=null)
            _ = await _bugReportRepository.AddAsync(BugReport);
            return RedirectToPage("../Index");
        }

    }
}
