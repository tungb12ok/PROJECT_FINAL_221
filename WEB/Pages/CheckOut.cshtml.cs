using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public CheckOutModel(QuickMarketContext context)
        {
            _context = context;
        }
        public List<UserShipped> UserShippeds { get; set; }
        public void OnGet()
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            UserShippeds = _context.UserShippeds.Where(x => x.Transaction.BuyerId == u.UserId).ToList();   
        }
    }
}
