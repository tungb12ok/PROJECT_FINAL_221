using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB.Pages
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            var session = HttpContext.Session;
            Extenstions.SessionExtensions.Set<User>(session, "User", null);
            return Redirect("Index");
        }
    }
}
