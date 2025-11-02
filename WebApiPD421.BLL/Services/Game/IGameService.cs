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
        Task<ServiceResponse> CreateAsync(CreateGameDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateGameDto dto);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceResponse> GetByIdAsync(string id);
        Task<ServiceResponse> GetAllAsync();
        public Task<ServiceResponse> GetByGenreAsync(string genre);
    }
}
