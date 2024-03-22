using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly QuickMarketContext context;
        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public string Mess {  get; set; }
        public string messCode { get; set; }
        [BindProperty]
        public string OTP { get; set; }
        [BindProperty]
        public string mode { get; set; }
        public ForgotPasswordModel(QuickMarketContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            mode = "";
        }
    }
}
