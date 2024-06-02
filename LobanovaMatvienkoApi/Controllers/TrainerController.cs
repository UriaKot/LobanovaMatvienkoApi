using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApi.Models;
using LobanovaMatvienkoApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LobanovaMatvienkoApi.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class TrainerController : ControllerBase
    {
        private IDbContextFactory<TrainerContext> _contextFactory;

        public TrainerController(IDbContextFactory<TrainerContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        /// <summary>
        /// Получение данных по всем тренерам
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            TrainerContext context = _contextFactory.CreateDbContext();
            return await context.Trainers.ToListAsync();
        }
        /// <summary>
        /// Получение данных по id тренера
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Trainer> Get(int id)
        {
            TrainerContext context = _contextFactory.CreateDbContext();
            return await context.Trainers.FindAsync(id);
        }
        /// <summary>
        /// Создание нового тренера
        /// </summary>
        /// <param name="trainer">Тренер</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Create([FromBody] Trainer trainer)
        {
            TrainerContext context = _contextFactory.CreateDbContext();
            await context.AddAsync(trainer);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Удаление тренера
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            TrainerContext context = _contextFactory.CreateDbContext();
            Trainer trainerForDelete = await context.Trainers.FindAsync(id);
            context.Remove(trainerForDelete);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Редактирование тренера
        /// </summary>
        /// <param name="trainer">Тренер</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] Trainer trainer)
        {
            TrainerContext context = _contextFactory.CreateDbContext();
            context.Trainers.Update(trainer);
            await context.SaveChangesAsync();
        }
    }
}
