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
                .Where(p => p.StatusId == 1)
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
        public async Task<IActionResult> OnPostAddToFavouriteAsync(int productId)
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if(u == null)
            {
                return Redirect("/SignIn");
            }
            // Lấy UserId của người dùng hiện tại
            // Kiểm tra xem sản phẩm đã được yêu thích trước đó chưa
            var existingFavourite = await _context.Favorites.FirstOrDefaultAsync(f => f.ProductId == productId && f.UserId == u.UserId);

            // Nếu sản phẩm chưa được yêu thích, thêm vào bảng Favorites
            if (existingFavourite == null)
            {
                var favourite = new Favorite
                {
                    UserId = u.UserId, // Thay YourUserId bằng UserId của người dùng hiện tại
                    ProductId = productId,
                    DateAdded = DateTime.Now
                };
                try
                {
                    _context.Favorites.Add(favourite);
                    await _context.SaveChangesAsync();
                    TempData["messSuccess"] = "Add into my favories Success";
                }
                catch (Exception ex)
                {
                    TempData["mess"] = "Add into my favories failed";
                }
            }
            else
            {
                TempData["mess"] = "Product in exits into My Favorites";
            }
            return RedirectToPage();
        }
    }
}

