using LobanovaMatvienkoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LobanovaMatvienkoApi.Context
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
