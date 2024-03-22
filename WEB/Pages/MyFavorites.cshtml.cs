using DataAccess.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WEB.Pages
{
    public class MyFavoritesModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public MyFavoritesModel(QuickMarketContext context)
        {
            _context = context;
        }
        public List<Favorite> Favorites { get; set; }
        public string Mess { get; set; }

        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; }
        const int pageSize = 2;
        public IActionResult OnGet(int? pageNumber)
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (u == null)
            {
                TempData["mess"] = "You must be SignIn to view to my Favories!";
                return Redirect("/Index");
            }
            Favorites = _context.Favorites
                .Include(x => x.Product.ProductImages)
                .Include(x => x.User)
                .Where(x => x.UserId == u.UserId && x.Product.StatusId == 1)
                .ToList();
            if (Favorites == null)
            {
                TempData["mess"] = "my Favories null!";
                return Redirect("/Index");
            }

            PageNumber = pageNumber ?? 1;
                        TotalPages = (int)Math.Ceiling(Favorites.Count / (double)pageSize);
            Favorites = Favorites
                .Skip((PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return Page();
        }
        public IActionResult OnGetRemove(int id)
        {
            User u = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");
            if (u == null)
            {
                TempData["mess"] = "You must be SignIn to Remve to my Favories!";
                return Redirect("/Index");
            }
            Favorites = _context.Favorites
                .Include(x => x.Product.ProductImages)
                .Include(x => x.User)
                .Where(x => x.UserId == u.UserId)
                .ToList();
            if (Favorites == null)
            {
                TempData["mess"] = "my Favories null!";
                return Redirect("/Index");
            }
            Favorite f = _context.Favorites.FirstOrDefault(x => u.UserId == x.UserId && x.ProductId == id);
            if (f == null)
            {
                TempData["mess"] = "Remove Favories Failed!";
                return Redirect("/Index");
            }
            else
            {
                _context.Favorites.Remove(f);
                _context.SaveChanges();
                TempData["messSuccess"] = "Remove Favories Success!";

                return Redirect("/MyFavorites");

            }
        }
    }
}
