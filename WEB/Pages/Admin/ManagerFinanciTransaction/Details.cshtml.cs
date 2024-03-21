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
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public DetailsModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

      public FinancialTransaction FinancialTransaction { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FinancialTransactions == null)
            {
                return NotFound();
            }

            var financialtransaction = await _context.FinancialTransactions.FirstOrDefaultAsync(m => m.TransactionId == id);
            if (financialtransaction == null)
            {
                return NotFound();
            }
            else 
            {
                FinancialTransaction = financialtransaction;
            }
            return Page();
        }
    }
}
