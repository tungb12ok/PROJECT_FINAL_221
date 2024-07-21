using BussinessLogic.Repository;
using DataAccess.Enum;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WEB.Extenstions;
namespace WEB.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly ILogger<SignUpModel> _logger;
        private UserRepository uRepo = new UserRepository();
        [BindProperty]
        public User User { get; set; }

        public SignUpModel(ILogger<SignUpModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Khởi tạo đối tượng User
            User = new User();
        }
        public IActionResult OnPost()
        {
            User.Status = StatusCommon.Active.ToString();
            User.DateCreated = DateTime.Now;
            User.RoldeId = 3;
            if (User != null)
            {
                try
                {
                    User uSignUp = uRepo.signUp(User);
                    if (uSignUp != null)
                    {
                        User.UserId = uSignUp.UserId;
                        ViewData["Message"] = "SignUp successfuly!";
                        string otp = GenerateOTP();
                        SaveOTPInSession(otp);
                        Services.EmailSender ed = new Services.EmailSender();
                        Extenstions.SessionExtensions.Set<User>(HttpContext.Session, "UserVeri", User);

                        ed.SendEmail(User.Email, "Veri Account", "You OTP Authentication: " + otp);
                        return RedirectToPage("/VeryPages");
                    }
                    else
                    {
                        ViewData["Message"] = "SignUp failed checking username and email";
                        return Page();
                    }

                }
                catch (Exception ex)
                {
                    ViewData["Message"] = "SignUp failed checking username and email";
                    return Page();
                }
                _logger.LogInformation("User registered successfully!");
                return RedirectToPage("/Index");
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
