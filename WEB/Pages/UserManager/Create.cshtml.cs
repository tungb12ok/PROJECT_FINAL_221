using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Models;
using WEB.Extenstions;
using DocumentFormat.OpenXml.Spreadsheet;

namespace WEB.Pages.UserManager
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public CreateModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public User user { get; set; }
        public IActionResult OnGet()
        {
            user = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "CategoryId", "CategoryName");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusName");
            return Page();
        }

        [BindProperty]
        public Product? Product { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Products == null || Product == null)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
