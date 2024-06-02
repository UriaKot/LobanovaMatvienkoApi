using LobanovaMatvienkoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LobanovaMatvienkoApi.Context
{
    public class WorkoutContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }
        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
