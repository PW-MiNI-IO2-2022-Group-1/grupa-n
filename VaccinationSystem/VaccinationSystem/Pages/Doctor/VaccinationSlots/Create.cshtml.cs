#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.Pages.Doctor.VaccinationSlots
{
    [Authorize(Roles = Roles.Doctor.Name)]
    public class CreateModel : PageModel
    {
        private readonly VaccinationSystem.Data.ApplicationDbContext _context;

        public CreateModel(VaccinationSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DoctorId"] = new SelectList(_context.Set<Data.Classes.Doctor>(), "Id", "Id");
        ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Id");
        ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Visit Visit { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Visit.Add(Visit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
