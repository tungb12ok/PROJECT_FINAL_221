using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Models;

namespace WEB.Pages.Manager.Categories
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public CreateModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusName");
            return Page();
        }

        [BindProperty]
        public ProductCategory ProductCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProductCategories == null || ProductCategory == null)
            {
                return Page();
            }

            _context.ProductCategories.Add(ProductCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
