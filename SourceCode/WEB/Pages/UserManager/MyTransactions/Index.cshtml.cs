using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

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
                U = new User { UserId = 1 };
            }

            MyList = _context.Transactions
                                .Include(x => x.UserShipped)
                                .Include(x => x.Buyer)
                                .Include(x => x.Seller)
                                .Include(x => x.Product)
                                .Where(t => t.SellerId == U.UserId)
                                .ToList();
            ViewData[nameof(U)] = U;
        }

        public JsonResult OnGetUserShippedDetails(int transactionId)
        {
            var userShipped = _context.Transactions
                                      .Include(t => t.UserShipped)
                                      .Where(t => t.TransactionId == transactionId)
                                      .Select(t => t.UserShipped)
                                      .FirstOrDefault();

            if (userShipped == null)
            {
                return new JsonResult(new { success = false, message = "User not found" });
            }

            return new JsonResult(new { success = true, userShipped });
        }
    }
}
