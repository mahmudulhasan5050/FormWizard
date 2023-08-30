using FormWizard.Data;
using FormWizard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormWizard.Pages.MyForms
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public MyForm myForm { get; set; }

        public IActionResult OnGet()
        {
            var categoryFromDb = _db.Category;
            var countryFromDb = _db.Country;

            if (categoryFromDb != null && countryFromDb != null)
            {
                IEnumerable<SelectListItem> categoryList = categoryFromDb.Select(u=>
                new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
                ).ToList();
                IEnumerable<SelectListItem> countryList = countryFromDb.Select(u =>
                new SelectListItem
                {
                    Text= u.Name,
                    Value = u.Id.ToString()
                }

                );
                ViewData["categoryList"] = categoryList;
                ViewData["countryList"] = countryList;

            }
            return Page();

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.MyForms.Add(myForm);
                _db.SaveChanges();
                TempData["success"] = "New Form has been created.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
