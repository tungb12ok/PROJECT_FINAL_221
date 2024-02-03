using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
            User = new User(); 
        }
    }
}
