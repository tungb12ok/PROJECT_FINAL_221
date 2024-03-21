using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using WEB.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;

namespace WEB.Pages
{
    public class IndexModel : PageModel
    {

        private readonly QuickMarketContext _context;

        public IndexModel(QuickMarketContext context)
        {
            _context = context;
        }
        public List<ProductViewModel> ProductsWithImages { get; set; }
        public List<Product> products { get; set; }

        public User user { get; }
        public void OnGet()
        {
            // Lấy danh sách sản phẩm với danh sách hình ảnh từ cơ sở dữ liệu
            ProductsWithImages = _context.Products
                .Include(p => p.ProductImages)
                .Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    UserId = p.UserId,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    DatePosted = p.DatePosted,
                    StatusId = p.StatusId,
                    ImageUrls = p.ProductImages.Select(pi => pi.ImageUrl).ToList()
                })
                .ToList();
        }
        public async Task<IActionResult> OnPostAddToFavouriteAsync(int productId, int userId)
        {
            // Lấy UserId của người dùng hiện tại
            // Kiểm tra xem sản phẩm đã được yêu thích trước đó chưa
            var existingFavourite = await _context.Favorites.FirstOrDefaultAsync(f => f.ProductId == productId);

            // Nếu sản phẩm chưa được yêu thích, thêm vào bảng Favorites
            if (existingFavourite == null)
            {
                var favourite = new Favorite
                {
                    UserId = userId, // Thay YourUserId bằng UserId của người dùng hiện tại
                    ProductId = productId,
                    DateAdded = DateTime.Now
                };

                _context.Favorites.Add(favourite);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}

