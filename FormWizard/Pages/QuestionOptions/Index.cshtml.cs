using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormWizard.Pages.QuestionOptions
{
    public class IndexModel : PageModel
    {
        public void OnGet(int questionid, string questiontype)
        {

            ViewData["QuestionId"] = questionid;
            ViewData["QuestionType"] = questiontype;
        }
    }
}
