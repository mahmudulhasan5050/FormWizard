using FormWizard.Data;
using FormWizard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FormWizard.Pages.QuestionConditions
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public QuestionCondition questionCondition { get; set; }
        public void OnGet(int questionconditionid,int questionid, int myformid)
        {
            questionCondition = _db.QuestionConditions.Find(questionconditionid);
           //var questionText = _db.Questions.FirstOrDefault(u => u.Id == questionid);
            ViewData["QuestionId"] = questionid;
            ViewData["MyFormId"] = myformid;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var formInfoFromDb = _db.Questions.FirstOrDefault(x => x.Id == questionCondition.QuestionId);
                _db.QuestionConditions.Update(questionCondition);
                _db.SaveChanges();
                TempData["success"] = "Question Condition has been updated.";
                return RedirectToPage("Index", new { questionid = questionCondition.QuestionId, myformid = formInfoFromDb.MyFormId });
            }
            return Page();
        }
    }
}
