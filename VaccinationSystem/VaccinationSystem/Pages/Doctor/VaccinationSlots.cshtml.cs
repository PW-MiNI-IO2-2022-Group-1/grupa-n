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

namespace VaccinationSystem.Pages.Doctor
{
    public class VaccinationSlotsModel : PageModel
    {
        private readonly VaccinationSystem.Data.ApplicationDbContext _context;

        public VaccinationSlotsModel(VaccinationSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Visit> Visit { get;set; }

        public async Task OnGetAsync()
        {
            Visit = await _context.Visit
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Include(v => v.Vaccine).ToListAsync();
        }
    }
}
