#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using Microsoft.AspNetCore.Identity;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Doctor.VaccinationSlots
{
    public class EditModel : PageModel
    {
        private readonly VaccinationSystem.Data.ApplicationDbContext _context;
        private readonly IBugReportRepository _bugReportRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(IBugReportRepository bugReportRepository, UserManager<ApplicationUser> userManager,VaccinationSystem.Data.ApplicationDbContext context)
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
                return BugReportUtility.NotFoundAndReport(null,"Id was null",_bugReportRepository);
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
           ViewData["DoctorId"] = new SelectList(_context.Set<Data.Classes.Doctor>(), "Id", "Id");
           ViewData["PatientId"] = new SelectList(_context.Set<Data.Classes.Patient>(), "Id", "Id");
           ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Visit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(Visit.Id))
                {
                    ApplicationUser = (Data.Classes.ApplicationUser)_userManager.GetUserAsync(User).Result;
                    return BugReportUtility.NotFoundAndReport(ApplicationUser,"Visit not Exist",_bugReportRepository);
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VisitExists(int id)
        {
            return _context.Visits.Any(e => e.Id == id);
        }
    }
}
