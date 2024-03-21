using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace WEB.Pages.Manager.ManagerAccount
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.Models.QuickMarketContext _context;

        public EditModel(DataAccess.Models.QuickMarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            ViewData["RoldeId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var errorMessage = "";
            var oldUser = _context.Users.FirstOrDefault(x => x.UserId == User.UserId);
            var existUserName = _context.Users.FirstOrDefault(x => x.Username == User.Username);

            if (existUserName != null)
            {
                errorMessage += "Username already exists.";
            }
            var existEmail = _context.Users.FirstOrDefault(x => x.Username == User.Username);
            if (existEmail != null)
            {
                errorMessage += "Email already exists.";
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                TempData["ErrorMessage"] = errorMessage;
                var user = await _context.Users.FirstOrDefaultAsync(m => m.UserId == User.UserId);
                if (user == null)
                {
                    return NotFound();
                }
                User = user;
                ViewData["RoldeId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
                return Page();
            }

            oldUser.Username = User.Username;
            oldUser.Email = User.Email;
            oldUser.PasswordHash = User.PasswordHash;
            oldUser.RoldeId = User.RoldeId;
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
