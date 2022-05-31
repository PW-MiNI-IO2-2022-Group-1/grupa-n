#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using Microsoft.AspNetCore.Identity;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Doctor.VaccinationSlots
{
    public class DeleteModel : PageModel
    {
        private readonly VaccinationSystem.Data.ApplicationDbContext _context;
        private readonly IBugReportRepository _bugReportRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteModel(IBugReportRepository bugReportRepository, UserManager<ApplicationUser> userManager, VaccinationSystem.Data.ApplicationDbContext context)
        {
            _context = context;
            _bugReportRepository = bugReportRepository;
            _userManager = userManager;
        }

        [BindProperty]
        public Visit Visit { get; set; }
        public Data.Classes.ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return BugReportUtility.NotFoundAndReport(null, "Id was null", _bugReportRepository);
            }

            Visit = await _context.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Include(v => v.Vaccine).FirstOrDefaultAsync(m => m.Id == id);

            if (Visit == null)
            {
                ApplicationUser = (Data.Classes.ApplicationUser)_userManager.GetUserAsync(User).Result;
                return BugReportUtility.NotFoundAndReport(ApplicationUser, "Visit was null", _bugReportRepository);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return BugReportUtility.NotFoundAndReport(null, "Id was null", _bugReportRepository);
            }

            Visit = await _context.Visits.FindAsync(id);

            if (Visit != null)
            {
                _context.Visits.Remove(Visit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
