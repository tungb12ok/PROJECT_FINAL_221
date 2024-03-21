using DataAccess.Models;
using Microsoft.AspNetCore.SignalR;

namespace WEB.Hubs
{
    public class ChatHub : Hub
    {
        private readonly QuickMarketContext _context = new QuickMarketContext();

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
        public async Task SendMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            // Xử lý tin nhắn ở đây
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}