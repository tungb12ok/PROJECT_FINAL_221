using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WEB.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public ProductDetailsModel(QuickMarketContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }
        public List<ProductImage> Images { get; set; }
        public IActionResult OnGet(int id)
        {
            Product = _context
                .Products
                .Include(x => x.ProductImages)
                .Include(x => x.User)
                .FirstOrDefault(x => x.ProductId == id && x.StatusId == 1);
            if(Product == null)
            {
                TempData["mess"] = "Product not found!";
                return Redirect("Index");
            }
            else
            {
                Images = _context.ProductImages.Where(x => x.ProductId == id).ToList();
                return Page();
            }
        }
    }
}
