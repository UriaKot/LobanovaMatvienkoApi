using LobanovaMatvienkoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LobanovaMatvienkoApi.Context
{
    public class SubscriptionContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public SubscriptionContext(DbContextOptions<SubscriptionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
