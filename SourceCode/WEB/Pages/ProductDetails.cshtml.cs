using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB.ViewModel;

namespace WEB.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public ProductDetailsModel(QuickMarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Product { get; set; }
        public List<ProductImage> Images { get; set; }
        [BindProperty]
        public List<CommentViewModel> ListComment { get; set; }
        public IActionResult OnGet(int id)
        {
            ListComment = _context.ProductReviews
                    .Include(x => x.User) // Assuming there's a navigation property named User
                    .Where(x => x.ProductId == id && x.ThreadId == null) // Filter by product ID and non-null thread ID
                    .Select(x => new CommentViewModel
                    {
                        ReviewID = x.ReviewId,
                        ProductID = x.ProductId,
                        Comment = x.Comment,
                        UserID = x.UserId,
                        User = x.User, // Assuming x.User is the related User entity
                        Comments = _context.ProductReviews
                                            .Include(x => x.User)
                                            .Where(pr => pr.ThreadId == x.ReviewId)
                                            .ToList()
                    })
                    .ToList();

            Product = _context
                        .Products
                        .Include(x => x.ProductImages)
                        .Include(x => x.User)
                        .FirstOrDefault(x => x.ProductId == id && x.StatusId == 1);
            if (Product == null)
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
        public IActionResult OnPost(int? tId, string comment, int pId)
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (u == null)
            {
                return Redirect("/SignIn");
            }
            ProductReview pr = new ProductReview()
            {
                ProductId = pId,
                UserId = u.UserId,
                Comment = comment,
                ReviewDate = DateTime.Now,
                ThreadId = tId
            };
            _context.ProductReviews.Add(pr);
            _context.SaveChanges();
            return Redirect("ProductDetails?id=" + pId);
        }
    }
}
