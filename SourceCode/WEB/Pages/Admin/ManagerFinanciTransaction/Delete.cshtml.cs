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
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public DeleteModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FinancialTransactions == null)
            {
                return NotFound();
            }
            var financialtransaction = await _context.FinancialTransactions.FindAsync(id);

            if (financialtransaction != null)
            {
                FinancialTransaction = financialtransaction;
                _context.FinancialTransactions.Remove(FinancialTransaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
