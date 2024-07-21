using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace WEB.Pages.Manager.Categories
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public IndexModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        public IList<ProductCategory> ProductCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProductCategories != null)
            {
                ProductCategory = await _context.ProductCategories
                .ToListAsync();
            }
        }
    }
}
