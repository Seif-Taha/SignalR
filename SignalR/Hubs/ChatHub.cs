using Microsoft.AspNetCore.SignalR;
using SignalR.Contexts;
using SignalR.Models;

namespace SignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatDbContext _context;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ChatDbContext context, ILogger<ChatHub> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Send(string userName, string message)
        {
            await Clients.All.SendAsync("ReciveMessage", userName, message);

            var msg = new Message()
            {
                UserName = userName,
                Text = message
            };

            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();
        }



    }
}
