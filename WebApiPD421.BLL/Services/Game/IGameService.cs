using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPD421.BLL.Dtos.Game;
using WebApiPD421.DAL.Entities;

namespace WebApiPD421.BLL.Services.Game
{
    public interface IGameService
    {
        Task<string> CreateAsync(CreateGameDto dto);
        Task<string> UpdateAsync(UpdateGameDto dto);
        Task<string> DeleteAsync(string id);
        Task<GameDto> GetByIdAsync(string id);
        Task<IEnumerable<GameDto>> GetAllAsync();
        public Task<IEnumerable<GameEntity>> GetByGenreAsync(string genre);
    }
}
