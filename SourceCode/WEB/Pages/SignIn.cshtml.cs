using DataAccess.Enum;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB.Extenstions;

namespace WEB.Pages
{
    public class SignInModel : PageModel
    {
        private readonly ILogger<SignInModel> _logger;
        private readonly QuickMarketContext _quickMarketContext;

        public SignInModel(ILogger<SignInModel> logger, QuickMarketContext quickMarketContext)
        {
            _logger = logger;
            _quickMarketContext = quickMarketContext;
        }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public string Mess { get; set; }
        public void OnGet()
        {
            User = new User();
        }
        public IActionResult OnPost()
        {
            if (User != null)
            {
                var u = _quickMarketContext.Users.FirstOrDefault(x => x.Username == User.Username && x.PasswordHash == User.PasswordHash);

                if (u != null)
                {
                    
                    var session = HttpContext.Session;
                    if(u.Status == StatusCommon.InActive.ToString())
                    {
                        Mess = "your account is baned!";
                        return Page();
                    } else if(u.Status == StatusCommon.Active.ToString())
                    {
                        string otp = Helper.GenerateOTP();
                        SaveOTPInSession(otp);
                        Services.EmailSender ed = new Services.EmailSender();
                        Extenstions.SessionExtensions.Set<User>(HttpContext.Session, "UserVeri", u);

                        ed.SendEmail(u.Email, "Veri Account", "You OTP Authentication: " + otp);
                        return RedirectToPage("/VeryPages");
                    }
                    else
                    {
                        Extenstions.SessionExtensions.Set<User>(session, "User", u);
                        if (u.RoldeId == 1)
                        {
                            return RedirectToPage("/Admin/Index");
                        }
                    }
                    return RedirectToPage("/Index"); 
                }
                else
                {
                    Mess = "Invalid username or password";
                }
            }

            return Page();
        }
        private void SaveOTPInSession(string otp)
        {
            HttpContext.Session.SetString("OTPAuthen", otp);
            HttpContext.Session.SetInt32("OTPEXPIRY", 60);
        }
    }
}
