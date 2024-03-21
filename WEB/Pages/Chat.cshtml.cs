using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WEB.Pages
{
    public class ChatModel : PageModel
    {
        private readonly QuickMarketContext _context;

        public ChatModel(QuickMarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Message> Messages { get; set; }
        [BindProperty]
        public User UserCurrent { get; set; }
        public User UserTo { get; set; } = null;
        public IActionResult OnGet(int reciveceder)
        {
            UserCurrent = Extenstions.SessionExtensions.Get<User>(HttpContext.Session, "User");

            if (UserCurrent == null)
            {
                return Redirect("/SignIn");
            }
            else
            {
                if (reciveceder != null)
                {
                    Messages = _context.Messages.Where(x => (x.ToUserId == reciveceder && x.FromUserId == UserCurrent.UserId) || (x.ToUserId == UserCurrent.UserId && x.FromUserId == reciveceder))
                    .Include(x => x.FromUser)
                    .Include(x => x.ToUser)
                    .ToList();
                    var list = _context.Messages
                                .Include(x => x.ToUser)
                                .Include(x => x.FromUser)
                                .Where(x => x.FromUserId == UserCurrent.UserId)
                                .Select(x => new
                                {
                                   UserFrom = x.FromUser,
                                   UserTo = x.ToUser
                                })
                                .Distinct()
                                .ToList();

                    ViewData["listView"] = list;
                    UserTo = _context.Users.FirstOrDefault(x => x.UserId == reciveceder);
                    if (UserTo == null)
                    {
                        ViewData["flag"] = 0;
                        return Page();
                    }
                    return Page();
                }
                else
                {
                    var list = _context.Messages
                                .Include(x => x.ToUser)
                                .Include(x => x.FromUser)
                                .Where(x => x.FromUserId == UserCurrent.UserId)
                                .Select(x => new
                                {
                                    UserFrom = x.FromUser,
                                    UserTo = x.ToUser
                                })
                                .Distinct()
                                .ToList();

                    ViewData["listView"] = list;
                    ViewData["flag"] = 0;
                    return Page();
                }
            }
        }
    }
}
