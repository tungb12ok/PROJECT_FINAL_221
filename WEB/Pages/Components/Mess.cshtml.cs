using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WEB.Pages.Components
{
    public class MessModel : PageModel
    {
        public string Message { get; set; }
        public string MessageType { get; set; }

        public void OnGet(string mess, string messType)
        {
            Message = mess;
            MessageType = messType switch
            {
                "messError" => "error",
                "messSuccess" => "success",
                _ => "info",
            };
        }
    }
}
