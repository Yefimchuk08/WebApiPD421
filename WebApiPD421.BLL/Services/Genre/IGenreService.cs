using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPD421.BLL.Dtos.Genre;
using WebApiPD421.DAL.Entities;

namespace WebApiPD421.BLL.Services.Genre
{
    public interface IGenreService
    {
        Task<string> CreateAsync(CreateGenreDto dto);
        Task<string> UpdateAsync(UpdateGenreDto dto);
        Task<string> DeleteAsync(string id);
        Task<GenreDto> GetByIdAsync(string id);
        Task<IEnumerable<GenreDto>> GetAllAsync();

    }
}
