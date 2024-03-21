using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB.ViewModels;

namespace WEB.Pages
{
    public class MyFavoritesModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public MyFavoritesModel(QuickMarketContext context)
        {
            _context = context;
        }
        public List<ProductViewModel> ProductsWithImages { get; set; }
        public List<Product> products { get; set; }

        public User user { get; }
        public List<Favorite> Favorites { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ProductsWithImages = await _context.Favorites
               .Include(f => f.Product)
               .ThenInclude(p => p.ProductImages)
               .Select(f => new ProductViewModel
               {
                   ProductId = f.Product.ProductId,
                   UserId = f.Product.UserId,
                   CategoryId = f.Product.CategoryId,
                   Name = f.Product.Name,
                   Description = f.Product.Description,
                   Price = f.Product.Price,
                   ImageUrls = f.Product.ProductImages.Select(pi => pi.ImageUrl).ToList()
               })
               .ToListAsync();
            return Page();
        }
    }
}
