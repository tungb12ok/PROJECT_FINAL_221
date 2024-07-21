using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB.Extenstions;
using BussinessLogic.Repository;
using WEB.Services;
namespace WEB.Pages
{
    public class ProfileModel : PageModel
    {
        public FinancialTransactionRepository ft = new FinancialTransactionRepository();
        private readonly ILogger<SignInModel> _logger;
        private readonly QuickMarketContext _quickMarketContext;
        
        [BindProperty]
        public string Amount { get; set; } = string.Empty;
        [BindProperty]
        public string CodeQR { get; set; } = string.Empty;
        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public int userID { get; set; }
        public ProfileModel(ILogger<SignInModel> logger, QuickMarketContext quickMarketContext)
        {
            _logger = logger;
            _quickMarketContext = quickMarketContext;
        }

        public void OnGet()
        {
            User = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            User = _quickMarketContext.Users
                            .Include(x => x.Wallet)
                            .Include(x => x.FinancialTransactions)
                            .FirstOrDefault(x => x.UserId == User.UserId);
        }
        public IActionResult OnPostChangePassword()
        {
            string curPass = Request.Form["currentPassword"];
            string pass = Request.Form["newPassword"];
            string rePass = Request.Form["confirmNewPassword"];

            User = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            User = _quickMarketContext.Users
                            .Include(x => x.Wallet)
                            .Include(x => x.FinancialTransactions)
                            .FirstOrDefault(x => x.UserId == User.UserId);
            bool flag = true;

            if (!curPass.Equals(User.PasswordHash))
            {
                flag = false;
                ViewData["CurPass"] = "Password is incorect!";
            }
            if (!pass.Equals(rePass))
            {
                flag = false;
                ViewData["RePass"] = "Re-Password must be same new password!";
            }
            if(flag)
            {
                User.PasswordHash = rePass;
                _quickMarketContext.SaveChanges();
                ViewData["Success"] = "Change password successfully!";
            }
            return Page();
        }
        public IActionResult OnPostPaid()
        {
            var financialTrans = new FinancialTransaction
            {
                UserId = User.UserId,
                TransactionType = "VND",
                Amount = Decimal.Parse(Amount == null ? "0" : Amount),
                TransactionDate = DateTime.Now,
                Status = TransactionStatus.Pending.ToString(),
                Description = CodeQR,
            };
            ft.toUpFinancialTransactions(financialTrans);
            return Redirect("/Profile");
        }
    }
}
