using FormWizard.Data;
using FormWizard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<Question> questions { get; set; }
        [BindProperty]
        public bool ShowAll { get; set; }
        [BindProperty(SupportsGet = true)]
        public int myFormId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string myFormName { get; set; }

        public async Task OnGetAsync(int myformid)
        {
            myFormId = myformid;
            var formFromDb = _db.MyForms.FirstOrDefault(u => u.Id == myformid);
            myFormName = formFromDb.Name;
            if (formFromDb != null)
            {
                questions = await GetQuestionsAsync(false);
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {

            questions = await GetQuestionsAsync(ShowAll);
            return Page();
        }

        private async Task<List<Question>> GetQuestionsAsync(bool showAll)
        {
            if (!ShowAll)
            {
                var query = _db.Questions.Where(u => u.MyFormId == myFormId && u.IsInUse == true).Include(u => u.MyForm);
                return await query.ToListAsync();
            }
            else
            {
                var query = _db.Questions.Where(u => u.MyFormId == myFormId).Include(u => u.MyForm);
                return await query.ToListAsync();
            }
        }
    }
}
