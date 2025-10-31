using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPD421.DAL.Entities;

namespace WebApiPD421.DAL.Repositories.Game
{
    public class GameRepository : GenericRepository<GameEntity, string>, IGameRepository
    {
        public GameRepository(AppDbContext context):base(context) { }
    }
}
