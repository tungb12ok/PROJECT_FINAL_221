﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.Enum;
using Microsoft.AspNetCore.Authorization;

namespace WEB.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;
        public List<String> StatusList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SelectedStatus { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public List<FinancialTransaction> FilteredTransactions { get; set; } = new List<FinancialTransaction>();

        public IndexModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        public IList<FinancialTransaction> FinancialTransaction { get; set; } = default!;
        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync(string SelectedStatus)
        {
            User user = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (user == null)
            {
               return Redirect("/SignIn");
            }
            else
            {
                if (user.RoldeId != 1)
                {
                    TempData["mess"] = "You must be admin!";
                    return Redirect("/Index");
                }
            }

            StatusList = Enum.GetValues<TransactionStatus>()
                           .Select(s => s.ToString())
                           .ToList();

            if (SelectedStatus != null)
            {
                FilteredTransactions = await _context.FinancialTransactions
            .Include(f => f.User)
            .Where(f => f.Status == SelectedStatus)
            .ToListAsync();
            }
            else
            {
                FilteredTransactions = await _context.FinancialTransactions
                .Include(f => f.User)
                .ToListAsync();
            }
            // Implement pagination
            const int pageSize = 10;
            TotalPages = (int)Math.Ceiling(FilteredTransactions.Count / (double)pageSize);
            FilteredTransactions = FilteredTransactions
                .Skip((PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            decimal totalAmount = await _context.FinancialTransactions
                                        .Where(f => f.Status == "Successful")
                                        .SumAsync(x => x.Amount);
            int totalSuccess = await _context.FinancialTransactions
                                          .Where(f => f.Status == "Successful")
                                          .CountAsync();

            ViewData["total"] = totalAmount.ToString();
            ViewData["totalSuccess"] = totalSuccess.ToString();
            return Page();

        }
        public async Task OnGetFilterAsync()
        {
            FilteredTransactions = await _context.FinancialTransactions
            .Include(f => f.User)
            .Where(f => f.Status == SelectedStatus)
            .ToListAsync();

            const int pageSize = 10;
            TotalPages = (int)Math.Ceiling(FilteredTransactions.Count / (double)pageSize);
            FilteredTransactions = FilteredTransactions
                .Skip((PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Lấy tổng số tiền thành công và tổng số giao dịch thành công
            decimal totalAmount = await _context.FinancialTransactions
                                        .Where(f => f.Status == "Successful")
                                        .SumAsync(x => x.Amount);
            int totalSuccess = await _context.FinancialTransactions
                                          .Where(f => f.Status == "Successful")
                                          .CountAsync();

            ViewData["total"] = totalAmount.ToString();
            ViewData["totalSuccess"] = totalSuccess.ToString();

        }

    }
}
