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

        public void OnGet()
        {

        }
    }
}
