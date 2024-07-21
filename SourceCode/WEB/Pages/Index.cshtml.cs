using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using WEB.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using BussinessLogic.Repository;
using BussinessLogic;
using DataAccess.Enum;

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
        public List<ProductCategory> ProductCategories { get; set; }
        public User user { get; }
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; }
         const int pageSize = 5;
        public void OnGet(string? name, int? min, int? max, int? category, int? pageNumber)
        {
            PageNumber = pageNumber ?? 1;
            products = filter(category, name, min, max, PageNumber);

            ProductCategories = _context.ProductCategories.ToList();

           
            TotalPages = (int)Math.Ceiling(products.Count / (double)pageSize);
            products = products
                .Skip((PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public async Task<IActionResult> OnPostAddToFavouriteAsync(int productId)
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (u == null)
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
        public List<Product> filter(int? cateId, string name, int? min, int? max, int? pageNumber)
        {
            List<Product> products = _context.Products

                .Include(x => x.User)
                    .Include(x => x.Category)
                    .Include(x => x.ProductImages)
                    .ToList();

           

            if (cateId != null)
            {
                products = _context.Products                    
                    .Include(x => x.Category)
                    .Include(x => x.ProductImages)
                    .Where(x => x.CategoryId == cateId).ToList();

            }
            if (name != null)
            {
                products = _context.Products.Where(x => x.Name.Contains(name)).ToList();

            }
            if (min != null && max != null)
            {
                products = _context.Products.Where(x => x.Price >= min && x.Price <= max).ToList();

            }
            if (min != null && max == null)
            {
                products = _context.Products.Where(x => x.Price >= min).ToList();

            }
            if (max != null && min == null)
            {
                products = _context.Products.Where(x => x.Price <= max).ToList();

            }
            products = products.Where(x => x.Status == StatusCommon.Active.ToString()).ToList();
            return products;
        }
    }
}

