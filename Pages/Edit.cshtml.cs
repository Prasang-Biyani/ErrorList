using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorList.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ErrorList.Pages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db) => this._db = db;
        [BindProperty]
        public Error Error { get; set; }
        public IActionResult OnGet(int id)
        {
            Error = _db.Errors.Find(id);
            if (Error == null)
                return RedirectToPage("/index");
            //_db.SaveChanges();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            _db.Attach(Error).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                _db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e) { throw new Exception($"Error {Error.Id} not found" + e.Message); }
            return RedirectToPage("./Index");
        }
    }
}