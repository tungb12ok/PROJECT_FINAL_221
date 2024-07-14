using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.Enum;

namespace WEB.Pages.Admin.ManagerFinanciTransaction
{
    public class EditModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public List<string> StatusList { get; set; }
        public EditModel(QuickMarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FinancialTransaction FinancialTransaction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialTransaction = await _context.FinancialTransactions
                .Include(x => x.User)
                .FirstOrDefaultAsync(m => m.TransactionId == id);

            if (financialTransaction == null)
            {
                return NotFound();
            }

            FinancialTransaction = financialTransaction;
            StatusList = Enum.GetValues<TransactionStatus>().Select(s => s.ToString()).ToList();
            ViewData["Status"] = new SelectList(StatusList);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var financialTransactionToUpdate = await _context.FinancialTransactions
                .FirstOrDefaultAsync(e => e.TransactionId == FinancialTransaction.TransactionId);

            if (financialTransactionToUpdate == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính
            financialTransactionToUpdate.Status = FinancialTransaction.Status;
            financialTransactionToUpdate.TransactionType = FinancialTransaction.TransactionType;
            financialTransactionToUpdate.Amount = FinancialTransaction.Amount;
            financialTransactionToUpdate.TransactionDate = FinancialTransaction.TransactionDate;
            financialTransactionToUpdate.Description = FinancialTransaction.Description;

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

            return RedirectToPage("/Admin/Index");
        }

        private bool FinancialTransactionExists(int id)
        {
            return _context.FinancialTransactions.Any(e => e.TransactionId == id);
        }
    }
}
