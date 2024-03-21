using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WEB.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public CheckOutModel(QuickMarketContext context)
        {
            _context = context;
        }
        public Product Product { get; set; }
        public List<UserShipped> UserShippeds { get; set; }
        public IActionResult OnGet(int id)
        {
            Product = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.User)
                .FirstOrDefault(x => x.ProductId == id && x.StatusId == 1);
            if (Product == null)
            {
                return Redirect("/Index");
            }
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            UserShippeds = _context.UserShippeds.Where(x => x.Transaction.BuyerId == u.UserId).ToList();   
            return Page();
        }
    }
}
