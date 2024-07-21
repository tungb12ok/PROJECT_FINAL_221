using DataAccess.Enum;
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
        [BindProperty]
        public UserShipped Shipped { get; set; } = new UserShipped();
        public IActionResult OnGet(int id)
        {
            Product = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.User)
                .FirstOrDefault(x => x.ProductId == id && x.Status == StatusCommon.Active.ToString());
            if (Product == null)
            {
                return Redirect("/Index");
            }
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if(u == null)
            {
                return Redirect("/SignIn");

            }
            UserShippeds = _context.UserShippeds.Where(x => x.Transaction.BuyerId == u.UserId).ToList();   
            return Page();
        }
        public IActionResult OnPost(int id, int pId, int uId, int p)
        {
            
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");

            Transaction t = new Transaction()
            {
                ProductId = pId,
                BuyerId = u.UserId,
                SellerId = uId,
                Amount = p + 250000 + 10000,
                Status = TransactionStatus.Successful.ToString()
            };
            try
            {
                _context.Transactions.Add(t);
                _context.SaveChanges();
                Shipped.TransactionId = t.TransactionId;
                Shipped.Status = StatusProcess.Pending.ToString();
                Shipped.AddressType = "";
                _context.UserShippeds.Add(Shipped);
                _context.SaveChanges();
                TempData["messSuccess"] = "Please waitting for Saller!";
            } catch (Exception ex)
            {
                TempData["mess"] = "Order Failed!";
            }
            return Redirect("Index");
        }
    }
}
