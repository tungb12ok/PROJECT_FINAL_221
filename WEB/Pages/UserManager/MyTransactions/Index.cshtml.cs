using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace WEB.Pages.UserManager.MyTransactions
{
    public class IndexModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public IndexModel(QuickMarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Transaction> MyList { get; set; }
        [BindProperty]
        public User U { get; set; }

        public void OnGet()
        {

            var session = HttpContext.Session;
            U = Extenstions.SessionExtensions.Get<User>(session, "User");
            if (U == null)
            {
                U = new User();
                U.UserId = 1;
            }

            MyList = _context.Transactions
                                .Include(x => x.UserShipped)
                                .Include(x => x.Status)
                                .Include(x => x.Buyer)
                                .Include(x => x.Seller)
                                .Include(x => x.Product)
                                .Where(t => t.SellerId == U.UserId || t.BuyerId == U.UserId)
                                .ToList();
            ViewData[nameof(U)] = U;

        }
    }
}
