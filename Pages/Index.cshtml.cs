using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorList.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErrorList.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db) => this._db = db;
        public IList<Error> Errors { get; set; }
        public void OnGet()
        {
           Errors = _db.Errors.ToList();
            //return error;
        }
    }
}
