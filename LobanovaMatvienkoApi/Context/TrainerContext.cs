using LobanovaMatvienkoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LobanovaMatvienkoApi.Context
{
    public class TrainerContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public TrainerContext(DbContextOptions<TrainerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
