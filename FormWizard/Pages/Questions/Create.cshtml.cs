using FormWizard.Data;
using FormWizard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormWizard.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;            
        }
        [BindProperty]
        public Question question { get; set; }
        public void OnGet(int myformid)
        {
            ViewData["MyFormId"] = myformid;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MyFormId"] = question.MyFormId;
            }
            if (ModelState.IsValid)
            {
                _db.Questions.Add(question);
                _db.SaveChanges();
                TempData["success"] = "New Question has been created.";
                return RedirectToPage("Index", new { myformid = question.MyFormId });
            }
            return Page();
        }
    }
}
