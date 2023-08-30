using FormWizard.Data;
using FormWizard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static FormWizard.Model.Question;

namespace FormWizard.Pages.QuestionOptions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public QuestionOption questionOption { get; set; }
        public IActionResult OnGet(int questionid, string questiontype)
        {
            ViewData["QuestionId"] = questionid;
            ViewData["QuestionType"] = questiontype;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["QuestionId"] = questionOption.QuestionId;
                ViewData["QuestionType"] = questionOption.OptionType;
            }
            if (ModelState.IsValid)
            {
                _db.QuestionOptions.Add(questionOption);
                _db.SaveChanges();
                TempData["success"] = "Option created successfully!";
                return RedirectToPage("Index", new { questionid = questionOption.QuestionId, questiontype = questionOption.OptionType });
            }
            return Page();
        }
    }
}
