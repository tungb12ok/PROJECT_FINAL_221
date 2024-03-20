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

            List<Transaction> transSall = _context.Transactions
                                            .Include(x => x.UserShipped)
                                            .Include(x => x.Status)
                                            .Include(x => x.Buyer)
                                            .Include(x => x.Seller)
                                            .Where(t => t.SellerId == U.UserId).ToList();
            List<Transaction> transBuy = _context.Transactions
                                            .Include(x => x.UserShipped)
                                            .Include(x => x.Status)
                                            .Include(x => x.Buyer)
                                            .Include(x => x.Seller)
                                            .Where(t => t.BuyerId == U.UserId).ToList();

            if (transSall != null && transSall.Any())
            {
                foreach (Transaction transaction in transSall)
                {
                    MyList.Add(transaction);
                }
            }

            if (transBuy != null && transBuy.Any())
            {

                foreach (Transaction transaction in transBuy)
                {
                    MyList.Add(transaction);
                }
            }
        }
    }
}
