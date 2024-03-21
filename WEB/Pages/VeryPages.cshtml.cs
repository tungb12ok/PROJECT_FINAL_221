using BussinessLogic.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using WEB.Extenstions;
namespace WEB.Pages
{
    public class VeryPagesModel : PageModel
    {
        private readonly ILogger<SignUpModel> _logger;
        private readonly QuickMarketContext _context;
        private UserRepository uRepo = new UserRepository();

        [BindProperty]
        public string OPT { get; set; }
        public VeryPagesModel(ILogger<SignUpModel> logger, QuickMarketContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet()
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "UserVeri");
            if (u == null)
            {
                return RedirectToPage("SignIn");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "UserVeri");
            if (u == null)
            {
                return RedirectToPage("SignIn");
            }
            else
            {
                string otp = HttpContext.Session.GetString("OTPAuthen");
                if (otp == null)
                {
                    ViewData["mess"] = "OPT is expired";
                    return Page();
                }
                else
                {
                    if (otp == OPT)
                    {
                        User uUdate = _context.Users.FirstOrDefault(x => x.UserId == u.UserId);
                        uUdate.StatusId = 7;
                        _context.SaveChanges();
                        Extenstions.SessionExtensions.Set<User>(HttpContext.Session, "User", uUdate);
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        ViewData["mess"] = "Account veried Failed!";
                        ViewData["flag"] = 1;
                    }
                }
                return Page();

            }
        }
        public IActionResult OnGetReOPT()
        {
            string otp = Extenstions.Helper.GenerateOTP();
            SaveOTPInSession(otp);
            Services.EmailSender e = new Services.EmailSender();
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "UserVeri");

            e.SendEmail(u.Email, "Verify account", "OTP: " + otp);
            return Page();
        }
        private void SaveOTPInSession(string otp)
        {
            HttpContext.Session.SetString("OTPAuthen", otp);
            HttpContext.Session.SetInt32("OTPEXPIRY", 60);
        }
    }
}
