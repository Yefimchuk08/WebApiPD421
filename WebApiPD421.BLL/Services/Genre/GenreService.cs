using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApiPD421.BLL.Dtos.Genre;
using WebApiPD421.DAL.Entities;
using WebApiPD421.DAL.Repositories.Genre;

namespace WebApiPD421.BLL.Services.Genre
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<ServiceResponse> CreateAsync(CreateGenreDto dto)
        {
            if (await _genreRepository.IsExistsAsync(dto.Name))
            {
                return new ServiceResponse
                {
                    Message = $"Жанр {dto.Name} уже шснує",
                    IsSuccess = false,
                    HttpStatusCode = HttpStatusCode.BadRequest
                };  
            }
            var entity = new GenreEntity
            {
                Name = dto.Name,
                NormalizedName = dto.Name.ToUpper()
            };

            await _genreRepository.CreateAsync(entity);

            return new ServiceResponse
            {
                Message = $"Жанр {dto.Name} успішно створено",
                HttpStatusCode = HttpStatusCode.Created
            };
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var entity = await _genreRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return new ServiceResponse
                {
                    Message = $"Жанр з id '{id}' не знайдено",
                    IsSuccess = false,
                    HttpStatusCode = HttpStatusCode.NotFound
                   
                };
            }

            await _genreRepository.DeleteAsync(entity);

            return new ServiceResponse
            {
                Message = $"Жанр '{entity.Name}' видалено",
                
            } ;
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _genreRepository.GetAll().ToListAsync();

            var dtos = entities.Select(e => new GenreDto
            {
                Id = e.Id,
                Name = e.Name
            });

            return new ServiceResponse
            {
                Message = "Категорії отримано",
                Data = dtos
            };
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var entity = await _genreRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return new ServiceResponse
                {
                    Message = $"Жанр з id '{entity.Id}' не знайдено",
                    HttpStatusCode = HttpStatusCode.NotFound,
                    IsSuccess = false
                };
            }

            var dto = new GenreDto
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return new ServiceResponse
            {
                Message = $"Жанр з id '{entity.Id}' знайдено",
                Data = dto
            };
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateGenreDto dto)
        {
            if (await _genreRepository.IsExistsAsync(dto.Name))
            {
                return new ServiceResponse
                {
                    Message = $"Жанр під назвою '{dto.Name}' вже існує",
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    IsSuccess = false
                };
            }

            var entity = await _genreRepository.GetByIdAsync(dto.Id);

            if (entity == null)
            {
                return  new ServiceResponse
                {
                    Message = $"Жанр з id '{dto.Id}' не знайдено",
                    HttpStatusCode = HttpStatusCode.NotFound,
                    IsSuccess = false
                };
            }

            entity.Name = dto.Name;
            entity.NormalizedName = dto.Name.ToUpper();

            await _genreRepository.UpdateAsync(entity);

            return new ServiceResponse 
            { 
                Message = $"Жанр '{dto.Name}' оновлено",
                HttpStatusCode = HttpStatusCode.OK 
            };
        }
    }
}
