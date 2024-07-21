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
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public DeleteModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }
        [BindProperty]

        public string Mess { get; set; }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
                product.Status = StatusCommon.InActive.ToString();
                _context.SaveChanges();
            }
            Mess = "Update Success";
            return Redirect("/Manager/ManagerProduct");
        }
    }
}
