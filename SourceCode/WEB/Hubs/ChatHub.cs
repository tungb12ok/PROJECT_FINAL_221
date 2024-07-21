using DataAccess.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WEB.Extenstions;

namespace WEB.Hubs
{
    public class ChatHub : Hub
    {
        private readonly QuickMarketContext _context = new QuickMarketContext();

        public async Task SendMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();

            var sender = "user" + message.FromUserId;
            var receiver = "user" + message.ToUserId;

            string group = Helper.roomConnect(sender, receiver);
            // Send the message to the specific group
            await Clients.Group(group).SendAsync("ReceiveMessage", message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}