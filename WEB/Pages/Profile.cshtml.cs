using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB.Extenstions;
using BussinessLogic.Repository;
namespace WEB.Pages
{
    public class ProfileModel : PageModel
    {
        public FinancialTransactionRepository ft = new FinancialTransactionRepository();
        private readonly ILogger<SignInModel> _logger;
        private readonly QuickMarketContext _quickMarketContext;
        [BindProperty]
        public string curPass { get; set; }
        [BindProperty]
        public string pass { get; set; }
        [BindProperty]
        public string Amount { get; set; } = string.Empty;
        [BindProperty]
        public string rePass { get; set; }
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
            // Xử lý logic cho Action 2
            return Page();
        }
        public IActionResult OnPostPaid()
        {
            // Xử lý logic cho Action 2
            var financialTrans = new FinancialTransaction
            {
                UserId = User.UserId,
                TransactionType = "VND",
                Amount = Decimal.Parse(Amount == null ? "0" : Amount),
                TransactionDate = DateTime.Now,
                Status = TransactionStatus.Pending.ToString(),
                Description = CodeQR,
            };
            try
            {
                ft.toUpFinancialTransactions(financialTrans);
            }
            catch (Exception ex)
            {
                return Redirect("/Error");
            }
            return Redirect("/Profile");
        }
    }
}
