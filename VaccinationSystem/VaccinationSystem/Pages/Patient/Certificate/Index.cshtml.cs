#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;
using VaccinationSystem.Services;

namespace VaccinationSystem.Pages.Patient.Certificate
{
    [Authorize(Roles = Roles.Patient.Name)]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVisitRepository _visitRepository;
        private readonly ICertificateGeneratorService _certificateGenerator;

        public IndexModel(UserManager<ApplicationUser> userManager, IVisitRepository visitRepository, ICertificateGeneratorService certificateGenerator)
        {
            _userManager = userManager;
            _visitRepository = visitRepository;
            _certificateGenerator = certificateGenerator;
        }

        public async Task<IActionResult> OnGetAsync(int visitId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var visit = await _visitRepository.GetAsync(visitId);

            if (visit is null)
            {
                return NotFound();
            }

            if (visit.Status != VaccinationStatus.Completed)
            {
                return BadRequest();
            }

            if (visit.PatientId != currentUser.Id)
            {
                return Unauthorized();
            }

            var fileBytes = _certificateGenerator.Generate(new [] {visit});
            return File(fileBytes, "application/pdf");
        }
    }
}
