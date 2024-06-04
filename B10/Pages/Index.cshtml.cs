using B10.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace B10.Pages
{
    public class IndexModel : PageModel
    {
        public string srp;
        public string eng;
        public string opis;

        private readonly RecnikService _recnikService;

        public IndexModel(RecnikService recnikService)
        {
            _recnikService = recnikService;
        }

        [BindProperty]
        public string Engleski { get; set; }


        [BindProperty]
        public string Srpski { get; set; }


        [BindProperty]
        public string Opis { get; set; }

        [BindProperty]
        public string Smer { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Prevod prevod = null;

            if (Smer == "0")
            {
                prevod = _recnikService.PrevediEngleski(Engleski);
            }

            if (Smer == "1")
            {
                prevod = _recnikService.PrevediSrpski(Srpski);
            }

            if (prevod != null)
            {
                srp = prevod.Srpski;
                eng = prevod.Engleski;
                opis = prevod.Opis;


                RedirectToPage("/Index");
            }
        }
    }
}
