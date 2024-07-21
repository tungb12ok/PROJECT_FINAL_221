using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.Enum;

namespace WEB.Pages.UserManager.ManagerProduct
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public IndexModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;
        [BindProperty]

        public string Mess { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            User user = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (user == null)
            {
                return Redirect("/SignIn");
            }

            if (user.RoldeId != 1)
            {
                Product = await _context.Products
                    .Include(p => p.User)
                    .Include(p => p.Category)
                    .Where(p => p.UserId == user.UserId)
                    .ToListAsync();
            }
            else
            {
                Product = await _context.Products
                    .Include(p => p.Category)
                    .ToListAsync();
            }

            return Page();
        }
        public IActionResult OnGetUpdateStatus(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = _context.Products.FirstOrDefault(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                product.Status = StatusCommon.Active.ToString();
                _context.SaveChanges();
            }
            Mess = "Update Success";
            return Redirect("/Manager/ManagerProduct");
        }

    }
}
