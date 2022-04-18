#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Doctor.VaccinationSlots
{
    [Authorize(Roles = Roles.Doctor.Name)]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDoctorRepository _doctorRepository;
        public Data.Classes.Doctor Doctor { get; private set; }
        public IList<Visit> Visits { get; private set; }
        public IndexModel(UserManager<ApplicationUser> userManager, IDoctorRepository doctorRepository)
        {
            _userManager = userManager;
            _doctorRepository = doctorRepository;
        }

        public async Task OnGetAsync()
        {
            Doctor = (Data.Classes.Doctor) await _userManager.GetUserAsync(User);
            Visits = await _doctorRepository.GetVisits(Doctor.Id);

            ViewData["Message"] = $"Welcome {Doctor.FirstName} {Doctor.LastName}";
        }
    }
}
