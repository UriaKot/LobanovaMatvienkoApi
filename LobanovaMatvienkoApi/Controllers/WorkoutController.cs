using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LobanovaMatvienkoApi.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private IDbContextFactory<WorkoutContext> _contextFactory;

        public WorkoutController(IDbContextFactory<WorkoutContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        /// <summary>
        /// Получение данных по всем тренеровкам
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Workout>> GetAllAsync()
        {
            WorkoutContext context = _contextFactory.CreateDbContext();
            return await context.Workouts.ToListAsync();
        }
        /// <summary>
        /// Получение данных по id тренеровки
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Workout> Get(int id)
        {
            WorkoutContext context = _contextFactory.CreateDbContext();
            return await context.Workouts.FindAsync(id);
        }
        /// <summary>
        /// Создание новой тренеровки
        /// </summary>
        /// <param name="workout">Тренеровка</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Create([FromBody] Workout workout)
        {
            WorkoutContext context = _contextFactory.CreateDbContext();
            await context.AddAsync(workout);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Удаление тренеровки
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            WorkoutContext context = _contextFactory.CreateDbContext();
            Workout workoutForDelete = await context.Workouts.FindAsync(id);
            context.Remove(workoutForDelete);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Редактирование тренеровки
        /// </summary>
        /// <param name="workout">Тренеровка</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] Workout workout)
        {
            WorkoutContext context = _contextFactory.CreateDbContext();
            context.Workouts.Update(workout);
            await context.SaveChangesAsync();
        }
 
    }
}
