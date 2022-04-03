﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.Pages.Doctor.VaccinationSlots
{
    public class DetailsModel : PageModel
    {
        private readonly VaccinationSystem.Data.ApplicationDbContext _context;

        public DetailsModel(VaccinationSystem.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Visit Visit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visit = await _context.Visit
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Include(v => v.Vaccine).FirstOrDefaultAsync(m => m.Id == id);

            if (Visit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
