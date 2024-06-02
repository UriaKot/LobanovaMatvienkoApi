using LobanovaMatvienkoApi.Context;
using LobanovaMatvienkoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LobanovaMatvienkoApi.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class ClientController : ControllerBase
    {
        private IDbContextFactory<ClientContext> _contextFactory;

        public ClientController(IDbContextFactory<ClientContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// Получение данных по всем клиентам
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Client>> GetAllAsync() 
        {
            ClientContext context = _contextFactory.CreateDbContext();
            return await context.Clients.ToListAsync();
        }
        /// <summary>
        /// Получение данных по id клиента
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Client> Get(int id)
        {
            ClientContext context = _contextFactory.CreateDbContext();
            return await context.Clients.FindAsync(id);
        }

        /// <summary>
        /// Создание нового клиента
        /// </summary>
        /// <param name="client">Клиент</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Create([FromBody]Client client)
        {
            ClientContext context = _contextFactory.CreateDbContext();
            await context.AddAsync(client);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            ClientContext context = _contextFactory.CreateDbContext();
            Client clientForDelete = await context.Clients.FindAsync(id);
            context.Remove(clientForDelete);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// Редактирование клиента
        /// </summary>
        /// <param name="client">Клиент</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] Client client)
        {
            ClientContext context = _contextFactory.CreateDbContext();
            context.Clients.Update(client);
            await context.SaveChangesAsync();
        }
      
    }
}

