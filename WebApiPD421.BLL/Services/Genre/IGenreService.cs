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
        Task<ServiceResponse> CreateAsync(CreateGenreDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateGenreDto dto);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceResponse> GetByIdAsync(string id);
        Task<ServiceResponse> GetAllAsync();

    }
}
