using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using WEB.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using DocumentFormat.OpenXml.Spreadsheet;
using WEB.Extenstions;
namespace WEB.Pages
{
    public class IndexModel : PageModel
    {

        private readonly QuickMarketContext _context;


        [BindProperty]
        public int UserID { get; set; }
        [BindProperty]
        public int ProductID { get; set; }
        public IndexModel(QuickMarketContext context)
        {
            _context = context;
        }
        public List<ProductViewModel> ProductsWithImages { get; set; }

        [BindProperty]
        public User user { get; set; }
        public void OnGet()
        {
            user = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            //products=_context.Products.ToList();
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
        public async Task<IActionResult> OnPostAddToFavouriteAsync()
        {
            // Lấy UserId của người dùng hiện tại
            // Kiểm tra xem sản phẩm đã được yêu thích trước đó chưa
            var existingFavourite = await _context.Favorites.FirstOrDefaultAsync(f => f.ProductId == ProductID);

            // Nếu sản phẩm chưa được yêu thích, thêm vào bảng Favorites
            if (existingFavourite == null)
            {
                var favourite = new Favorite
                {
                    UserId = UserID, // Thay YourUserId bằng UserId của người dùng hiện tại
                    ProductId = ProductID,
                    DateAdded = DateTime.Now
                };

                _context.Favorites.Add(favourite);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}

