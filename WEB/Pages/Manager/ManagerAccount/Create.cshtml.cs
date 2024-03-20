using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Models;

namespace WEB.Pages.Manager.ManagerAccount
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
            ViewData["RoldeId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var errorMessage = "";

            var existingEmail = _context.Users.FirstOrDefault(x => x.Email == User.Email);
            if (existingEmail != null)
            {
                errorMessage += "Email already exists. ";
            }

            var existingUserName = _context.Users.FirstOrDefault(x => x.Username == User.Username);
            if (existingUserName != null)
            {
                errorMessage += "Username already exists. ";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                TempData["ErrorMessage"] = errorMessage;
                return RedirectToPage();
            }
            //if (!ModelState.IsValid || _context.Users == null || User == null)
            //{
            //    return Page();
            //}

            User.DateCreated = DateTime.Now;
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
