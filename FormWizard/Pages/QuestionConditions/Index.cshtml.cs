using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormWizard.Pages.QuestionConditions
{
    public class IndexModel : PageModel
    {
        public void OnGet(int questionid, int myformid)
        {
            ViewData["QuestionId"] = questionid;
            ViewData["MyFormId"] = myformid;
        }
    }
}
