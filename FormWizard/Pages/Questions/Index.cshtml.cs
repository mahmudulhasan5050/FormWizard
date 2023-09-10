using FormWizard.Data;
using FormWizard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FormWizard.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public IEnumerable<Question> questions { get; set; }
        public IActionResult OnGet(int myformid)
        {
            var formFromDb = _db.MyForms.FirstOrDefault(u => u.Id == myformid);
            if (formFromDb != null)
            {
                questions = _db.Questions.Where(u=>u.MyFormId == myformid).Include(f => f.MyForm);
                ViewData["FormName"] = formFromDb.Name;
                ViewData["MyFormId"] = myformid;
            }


            return Page();
        }
    }
}
