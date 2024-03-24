using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Models;

namespace WEB.Pages.Admin.ManagerFinanciTransaction
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public CreateModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public FinancialTransaction FinancialTransaction { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FinancialTransactions == null || FinancialTransaction == null)
            {
                return Page();
            }

            _context.FinancialTransactions.Add(FinancialTransaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
