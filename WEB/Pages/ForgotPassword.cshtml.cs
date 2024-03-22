using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly QuickMarketContext context;
        [BindProperty]
        public User User { get; set; } = new User();
        [BindProperty]
        public string Mess { get; set; }
        [BindProperty]
        public string MessSuccess { get; set; }
        public string messCode { get; set; }
        [BindProperty]
        public string OTP { get; set; }
        [BindProperty]
        public string mode { get; set; }
        public ForgotPasswordModel(QuickMarketContext context)
        {
            this.context = context;
        }

        public void OnGet(string Username)
        {

            if (Username != null)
            {
                User uChange = context.Users.FirstOrDefault(x => x.Username.Equals(Username));
                if (uChange != null)
                {
                    messCode = "OTP is sended your email checking email...";
                    mode = "hideUsername";
                    string otp = GenerateOTP();
                    SaveOTPInSession(otp);
                    Services.EmailSender ed = new Services.EmailSender();
                    ed.SendEmail(uChange.Email, "Reset password", "You OTP Authentication: " + otp);
                    Extenstions.SessionExtensions.Set<User>(HttpContext.Session, "UserChange", uChange);
                }
                else
                {
                    Mess = "Username incorrect!";
                }
            }
        }
        public IActionResult OnPostCheckOTP(string OTP)
        {
            string otp = HttpContext.Session.GetString("OTPAuthen");
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "UserChange");
            if(u == null)
            {
                TempData["mess"] = "Please input Username";
                return Page();
            }
            if (otp == null)
            {
                TempData["mess"] = "OPT is expired";
                return Page();
            }
            if (otp != null && u != null)
            {
                if (otp.Equals(OTP))
                {
                    mode = "change";
                    return Page();
                }
                else
                {
                    mode = "hideUsername";
                    TempData["mess"] = "OPT incorrect!";
                }
            }
            return Page();
        }
        public IActionResult OnPostChangePass(string pass, string rePass)
        {
            mode = "change";
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "UserChange");
            if(pass.Equals(rePass))
            {
                User update = context.Users.FirstOrDefault(x => x.UserId == u.UserId);
                update.PasswordHash = pass;
                context.SaveChanges();
                MessSuccess = "Update password successfuly!";
            }
            else
            {
                Mess = "Password and repasword must be same!";
            }
            return Page();
        }

        private string GenerateOTP()
        {
            // Tạo mã OTP ngẫu nhiên (ví dụ: một chuỗi 6 chữ số)
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // Mã OTP gồm 6 chữ số
        }
        private void SaveOTPInSession(string otp)
        {
            HttpContext.Session.SetString("OTPAuthen", otp);
            HttpContext.Session.SetInt32("OTPEXPIRY", 60);
        }
    }
}
