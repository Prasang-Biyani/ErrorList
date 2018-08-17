using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorList.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErrorList.Pages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        [BindProperty]
        public Error Error { get; set; }
        //public void OnGet()
        //{

        //}

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            this._db.Errors.Add(Error);
            this._db.SaveChanges();
            return RedirectToPage("/index");
        }
    }
}