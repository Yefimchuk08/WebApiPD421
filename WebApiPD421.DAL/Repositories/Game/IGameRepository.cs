using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPD421.DAL.Entities;

namespace WebApiPD421.DAL.Repositories.Game
{
    public interface IGameRepository : IGenericRepository<GameEntity, string>
    {
        Task<IEnumerable<GameEntity>> GetByCategoryAsync(string categoryName);
    }
}


