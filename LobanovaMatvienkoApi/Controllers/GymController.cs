using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LobanovaMatvienkoApi.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class GymController : ControllerBase
    {
        private IDbContextFactory<GymContext> _contextFactory;

        public GymController(IDbContextFactory<GymContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// Получение данных по всем залам
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Gym>> GetAllAsync() 
        {
            GymContext context = _contextFactory.CreateDbContext();
            return await context.Gyms.ToListAsync();
        }
        /// <summary>
        /// Получение данных по id зала
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Gym> Get(int id)
        {
            GymContext context = _contextFactory.CreateDbContext();
            return await context.Gyms.FindAsync(id);
        }

        /// <summary>
        /// Создание нового зала
        /// </summary>
        /// <param name="gym">Зал</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Create([FromBody] Gym gym)
        {
            GymContext context = _contextFactory.CreateDbContext();
            await context.AddAsync(gym);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Удаление зала
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            GymContext context = _contextFactory.CreateDbContext();
            Gym gymForDelete = await context.Gyms.FindAsync(id);
            context.Remove(gymForDelete);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Редактирование зала
        /// </summary>
        /// <param name="gym">Зал</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] Gym gym)
        {
            GymContext context = _contextFactory.CreateDbContext();
            context.Gyms.Update(gym);
            await context.SaveChangesAsync();
        }
       
    }
}
