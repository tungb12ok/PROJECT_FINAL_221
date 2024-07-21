using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WEB.Pages
{
    public class MyOrderModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public MyOrderModel(QuickMarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Transaction> MyOrder { get; set; }
        public void OnGet()
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            MyOrder = _context.Transactions
                                    .Include(x => x.Product)
                                    .Include(x => x.Buyer)
                                    .Include(x => x.Seller)
                                    .Where(x => x.BuyerId == u.UserId)
                                    .ToList();

        }
    }
}
