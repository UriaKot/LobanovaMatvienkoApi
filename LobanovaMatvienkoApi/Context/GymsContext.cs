using LobanovaMatvienkoApi.Models;
using LobanovaMatvienkoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LobanovaMatvienkoApi.Context
{
    public class GymContext : DbContext
    {
        public DbSet<Gym> Gyms { get; set; }
        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
