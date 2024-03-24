using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace WEB.Pages.Admin.ManagerFinanciTransaction
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public IndexModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        public IList<FinancialTransaction> FinancialTransaction { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FinancialTransactions != null)
            {
                FinancialTransaction = await _context.FinancialTransactions
                .Include(f => f.User).ToListAsync();
            }
        }
    }
}
