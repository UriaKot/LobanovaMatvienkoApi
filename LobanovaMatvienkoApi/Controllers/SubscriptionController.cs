using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LobanovaMatvienkoApi.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private IDbContextFactory<SubscriptionContext> _contextFactory;

        public SubscriptionController(IDbContextFactory<SubscriptionContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        /// <summary>
        /// Получение данных по всем абонементам
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            SubscriptionContext context = _contextFactory.CreateDbContext();
            return await context.Subscriptions.ToListAsync();
        }
        /// <summary>
        /// Получение данных по id абонемента
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<Subscription> Get(int id)
        {
            SubscriptionContext context = _contextFactory.CreateDbContext();
            return await context.Subscriptions.FindAsync(id);
        }


        /// <summary>
        /// Создание нового абонемента
        /// </summary>
        /// <param name="subscription">Абонемент</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Create([FromBody] Subscription subscription)
        {
            SubscriptionContext context = _contextFactory.CreateDbContext();
            await context.AddAsync(subscription);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Удаление абонемента
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            SubscriptionContext context = _contextFactory.CreateDbContext();
            Subscription subscriptionForDelete = await context.Subscriptions.FindAsync(id);
            context.Remove(subscriptionForDelete);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Редактирование абонемента
        /// </summary>
        /// <param name="subscription">Абонемент</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] Subscription subscription)
        {
            SubscriptionContext context = _contextFactory.CreateDbContext();
            context.Subscriptions.Update(subscription);
            await context.SaveChangesAsync();
        }
    }
}
