using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace WEB.Pages.Manager.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public DeleteModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ProductCategory ProductCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }

            var productcategory = await _context.ProductCategories.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (productcategory == null)
            {
                return NotFound();
            }
            else 
            {
                ProductCategory = productcategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }
            var productcategory = await _context.ProductCategories.FindAsync(id);

            if (productcategory != null)
            {
                ProductCategory = productcategory;
                _context.ProductCategories.Remove(ProductCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
