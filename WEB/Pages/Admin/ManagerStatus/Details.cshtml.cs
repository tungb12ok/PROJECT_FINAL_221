using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace WEB.Pages.Admin.ManagerStatus
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public DetailsModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

      public Status Status { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Statuses == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses.FirstOrDefaultAsync(m => m.StatusId == id);
            if (status == null)
            {
                return NotFound();
            }
            else 
            {
                Status = status;
            }
            return Page();
        }
    }
}
