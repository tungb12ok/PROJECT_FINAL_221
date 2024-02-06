using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
                    Extenstions.SessionExtensions.Set<User>(session, "User", u);
                    return RedirectToPage("/Index"); // Redirect to a success page
                }
                else
                {
                    Mess = "Invalid username or password";
                }
            }

            return Page();
        }

    }
}
