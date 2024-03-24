using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace WEB.Pages.UserManager.ManagerProduct
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public EditModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        [BindProperty]
        public List<string> ImageUrls { get; set; } = new List<string>();
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            User U = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            var Img = _context.ProductImages.Where(x => x.ProductId == id).ToList();
            ViewData["img"] = Img;
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "CategoryId", "CategoryName");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusName");
            ViewData["UserId"] = U;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
