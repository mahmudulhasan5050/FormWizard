using FormWizard.Data;
using FormWizard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormWizard.Pages.QuestionView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public IQueryable<Question> questions { get; set; }
        //[BindProperty]
        //public IQueryable<QuestionOption> questionOptions { get; set; }
        public IActionResult OnGet(int myformid)
        {
            questions = _db.Questions.Where(u => u.MyFormId == myformid);
            var questionOptions = _db.QuestionOptions.ToList();
            ViewData["questionOptions"] = questionOptions;
            return Page();
        }
    }
}
