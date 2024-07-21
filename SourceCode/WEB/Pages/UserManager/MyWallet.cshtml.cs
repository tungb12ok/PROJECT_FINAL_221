using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB.Pages.UserManager
{
    public class MyWalletModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public MyWalletModel(QuickMarketContext context)
        {
            _context = context;
        }
        public List<FinancialTransaction> ListFT { get; set; }
        public IActionResult OnGet()
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (u == null)
            {
                return Redirect("/SignIn");
            }
            ListFT = _context.FinancialTransactions.Where(x => x.UserId == u.UserId).ToList();
            if (ListFT.Count > 0)
            {
                decimal total = _context.FinancialTransactions.Where(x => x.UserId == u.UserId && x.Status.Equals("Successful")).Sum(x => x.Amount);
                var lastTime = _context.FinancialTransactions
                    .Where(ft => ft.UserId == u.UserId)
                    .OrderByDescending(ft => ft.TransactionDate)
                    .FirstOrDefault().TransactionDate;
                ViewData["summary"] = new { total, lastTime };
            }
            else
            {
                ViewData["summary"] = new { total = 0.00m, lastTime = "" };
            }
            return Page();

        }
    }
}
