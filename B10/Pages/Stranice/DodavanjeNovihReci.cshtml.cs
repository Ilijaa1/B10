using B10.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace B10.Pages.Stranice
{
    public class DodavanjeNovihReciModel : PageModel
    {
        private readonly RecnikService _recnikService;

        [BindProperty]
        public string SrpskaRec { get; set; }
        [BindProperty]
        public string EngleskaRec { get; set; }
        [BindProperty]
        public string OpisReci { get; set; }

        Prevod prevod;

        public DodavanjeNovihReciModel(RecnikService recnikService)
        {
            _recnikService = recnikService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                prevod = new Prevod
                {
                    Srpski = SrpskaRec,
                    Engleski = EngleskaRec,
                    Opis = OpisReci
                };
                _recnikService.DodajPrevod(prevod);
                return Redirect("../Index");
            }
            return Page();
        }
    }
}
