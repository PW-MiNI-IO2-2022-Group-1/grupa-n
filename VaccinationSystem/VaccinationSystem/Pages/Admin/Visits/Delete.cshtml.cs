using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Admin.Visits
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Visit Visit { get; set; }

        private readonly IVisitRepository _visitRepository;

        public DeleteModel(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var visit = await _visitRepository.GetAsync(id.Value);

            if (visit is null)
            {
                return NotFound();
            }

            Visit = visit;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            await _visitRepository.DeleteAsync(id.Value);

            return RedirectToPage("../Index");
        }
    }
}
