using FormWizard.Data;
using FormWizard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormWizard.Pages.MyForms
{
    
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public MyForm myForm { get; set; }
        public void OnGet(int myformid)
        {
            myForm = _db.MyForms.FirstOrDefault(u=>u.Id == myformid);
        }

        public IActionResult OnPost()
        {
            var myFormFromDb = _db.MyForms.Find(myForm.Id);
            if (myFormFromDb != null)
            {
                _db.MyForms.Remove(myFormFromDb);
                _db.SaveChanges();
                TempData["success"] = "Form has been deleted.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
