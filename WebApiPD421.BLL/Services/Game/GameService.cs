using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApiPD421.BLL.Dtos.Game;
using WebApiPD421.DAL.Entities;
using WebApiPD421.DAL.Repositories.Game;

namespace WebApiPD421.BLL.Services.Game
{


    internal class GameService : IGameService
    {

        private readonly IGameRepository _gameRepository;

        public GameService(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<ServiceResponse> CreateAsync(CreateGameDto dto)
        {
            if(await _gameRepository.IsExistsAsync(dto.Name))
            {
                return new ServiceResponse
                {
                    Message = $"Жанр {dto.Name} уже шснує",
                    IsSuccess = false,
                    HttpStatusCode = HttpStatusCode.BadRequest
                };
            }
            var entity = new GameEntity
            {
                Name = dto.Name,
                Price = dto.Price,
                RealizeDate = dto.RealizeDate,
                Publisher = dto.Publisher,
                Developer = dto.Developer,
                Category = dto.Category

            };

            await _gameRepository.CreateAsync(entity);

            return new ServiceResponse
            {
                Message = $"Жанр {dto.Name} успішно створено",
                HttpStatusCode = HttpStatusCode.Created
            };
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var entity = await _gameRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return new ServiceResponse
                {
                    Message = $"Жанр з id '{id}' не знайдено",
                    IsSuccess = false,
                    HttpStatusCode = HttpStatusCode.NotFound

                };
            }
            await _gameRepository.DeleteAsync(entity);

            return new ServiceResponse
            {
                Message = $"Жанр '{entity.Name}' видалено",

            };
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _gameRepository.GetAll().ToListAsync();

            var dtos = entities.Select(e => new GameDto
            {
                Name = e.Name,
                Price = e.Price,
                RealizeDate = e.RealizeDate,
                Publisher = e.Publisher,
                Developer = e.Developer,
                Category = e.Category
            });

            return new ServiceResponse
            {
                Message = "Категорії отримано",
                Data = dtos
            };
        }
        public async Task<ServiceResponse> GetByGenreAsync(string genre)
        {
            var games = (await _gameRepository.GetByGenreAsync(genre)).ToList();

            var entities = games.Select(e => new GameEntity
            {
                Name = e.Name,
                Price = e.Price,
                RealizeDate = e.RealizeDate,
                Publisher = e.Publisher,
                Developer = e.Developer,
                Category = e.Category
            });

            return new ServiceResponse
            {
                Message = "Жанри отримано",
                Data = entities
            };
        }
        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var entity = await _gameRepository.GetByIdAsync(id);

            if(entity == null)
            {
                return new ServiceResponse
                {
                    Message = $"Жанр з id '{entity.Id}' не знайдено",
                    HttpStatusCode = HttpStatusCode.NotFound,
                    IsSuccess = false
                };
            }

            var dto = new GameDto
            {
                Name = entity.Name,
                Price = entity.Price,
                RealizeDate = entity.RealizeDate,
                Publisher = entity.Publisher,
                Developer = entity.Developer,
                Category = entity.Category
            };

            return new ServiceResponse
            {
                Message = $"Жанр з id '{entity.Id}' знайдено",
                Data = dto
            };
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateGameDto dto)
        {
            if(await _gameRepository.IsExistsAsync(dto.Name))
            {
                return new ServiceResponse
                {
                    Message = $"Жанр під назвою '{dto.Name}' вже існує",
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    IsSuccess = false
                };
            }

            var entity = await _gameRepository.GetByIdAsync(dto.Id);

            if( entity == null)
            {
                return new ServiceResponse
                {
                    Message = $"Жанр з id '{dto.Id}' не знайдено",
                    HttpStatusCode = HttpStatusCode.NotFound,
                    IsSuccess = false
                };
            }

            entity.Name = dto.Name;
            entity.Price = dto.Price;
            entity.RealizeDate = dto.RealizeDate;
            entity.Publisher = dto.Publisher;
            entity.Developer = dto.Developer;
            entity.Category = dto.Category;

            await _gameRepository.UpdateAsync(entity);

            return new ServiceResponse
            {
                Message = $"Жанр '{dto.Name}' оновлено",
                HttpStatusCode = HttpStatusCode.OK
            };
        }
    }
}
