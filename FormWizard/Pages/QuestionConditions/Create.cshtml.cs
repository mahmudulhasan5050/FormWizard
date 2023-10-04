using FormWizard.Data;
using FormWizard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormWizard.Pages.QuestionConditions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public QuestionCondition questionCondition { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> optionList { get; set; }
        public void OnGet(int questionid, int myformid)
        {
            var questionOptionFromDb = _db.QuestionOptions.Where(u => u.QuestionId == questionid);
            if (questionOptionFromDb != null)
            {
                optionList = questionOptionFromDb.Select(u =>
                   new SelectListItem
                      {
                         Text = u.OptionText,
                         Value = u.OptionText
                      }).ToList();
                      }

            ViewData["QuestionId"] = questionid;
            ViewData["MyFormId"] = myformid;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["QuestionId"] = questionCondition.QuestionId;
            }
            if (ModelState.IsValid)
            {
                var myFormIdFromDb = _db.Questions.FirstOrDefault(x => x.Id == questionCondition.QuestionId);
                _db.QuestionConditions.Add(questionCondition);
                _db.SaveChanges();
                TempData["success"] = "New Question Condition has been created.";
                return RedirectToPage("Index", new { questionid = questionCondition.QuestionId, myformid = myFormIdFromDb.MyFormId });
            }
            return Page();
        }
    }
}
