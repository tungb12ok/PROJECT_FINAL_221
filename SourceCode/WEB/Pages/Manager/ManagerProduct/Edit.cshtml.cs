using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.Enum;

namespace WEB.Pages.UserManager.ManagerProduct
{
    public class EditModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public EditModel(QuickMarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        [BindProperty]
        public List<string> ImageUrls { get; set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            User U = WEB.Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                                        .Include(p => p.User)
                                        .Include(p => p.ProductImages)
                                        .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            Product = product;
            ImageUrls = product.ProductImages.Select(x => x.ImageUrl).ToList();

            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "CategoryId", "CategoryName");
            List<StatusCommon> statusList = Enum.GetValues(typeof(StatusCommon))
                                           .Cast<StatusCommon>()
                                           .ToList();
            ViewData["StatusId"] = new SelectList(statusList);
            ViewData["UserId"] = U;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var productToUpdate = await _context.Products
                                                .Include(p => p.ProductImages)
                                                .FirstOrDefaultAsync(p => p.ProductId == Product.ProductId);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            productToUpdate.Name = Product.Name;
            productToUpdate.Description = Product.Description;
            productToUpdate.Price = Product.Price;
            productToUpdate.CategoryId = Product.CategoryId;
            productToUpdate.Status = Product.Status;

            // Cập nhật các URL hình ảnh
            productToUpdate.ProductImages.Clear();
            foreach (var imageUrl in ImageUrls)
            {
                productToUpdate.ProductImages.Add(new ProductImage { ImageUrl = imageUrl });
            }

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
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
