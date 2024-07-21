using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Models;
using DataAccess.Enum;

namespace WEB.Pages.UserManager.ManagerProduct
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
            List<StatusCommon> statusList = Enum.GetValues(typeof(StatusCommon))
                                           .Cast<StatusCommon>()
                                           .ToList();
            ViewData["StatusId"] = new SelectList(statusList.Select(status => new { Value = status, Text = status.ToString() }), "Value", "Text");
            ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "CategoryId", "CategoryName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Username");
            return Page();
        }

        [BindProperty]
        public Product? Product { get; set; } = default!;

        [BindProperty]
        public List<string> ImageUrls { get; set; } = new List<string>();
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Products == null || Product == null)
            {
                return Page();
            }
            User user = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            Product.UserId = user.UserId;
            Product.DatePosted = DateTime.Now;
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            foreach (var imageUrl in ImageUrls)
            {
                var productImage = new ProductImage
                {
                    ProductId = Product.ProductId,
                    ImageUrl = imageUrl,
                    DateAdded = DateTime.Now
                };
                _context.ProductImages.Add(productImage);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
