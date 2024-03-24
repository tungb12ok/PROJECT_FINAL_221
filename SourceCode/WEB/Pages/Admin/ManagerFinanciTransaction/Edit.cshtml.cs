using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using System.Transactions;
using DataAccess.Enum;

namespace WEB.Pages.Admin.ManagerFinanciTransaction
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;
        public List<string> StatusList { get; set; }
        public EditModel(DataAccess.Models.QuickMarketContext context)
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

            var financialtransaction =  await _context.FinancialTransactions.Include(x=>x.User).FirstOrDefaultAsync(m => m.TransactionId == id);
            if (financialtransaction == null)
            {
                return NotFound();
            }
            FinancialTransaction = financialtransaction;


            StatusList = Enum.GetValues<DataAccess.Enum.TransactionStatus>()
                           .Select(s => s.ToString())
                           .ToList();
            ViewData["Status"] = StatusList;
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FinancialTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialTransactionExists(FinancialTransaction.TransactionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FinancialTransactionExists(int id)
        {
          return (_context.FinancialTransactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
