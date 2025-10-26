using Microsoft.EntityFrameworkCore;
using SignalR.Models;

namespace SignalR.Contexts
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Message> Messages { get; set; }


    }
}
