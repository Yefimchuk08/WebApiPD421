using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<string> CreateAsync(CreateGameDto dto)
        {
            if(await _gameRepository.IsExistsAsync(dto.Name))
            {
                return $"Жанр під назвою '{dto.Name}' вже існує";
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

            return $"Game complete";
        }

        public async Task<string> DeleteAsync(string id)
        {
            var entity = await _gameRepository.GetByIdAsync(id);

            if(entity == null)
            {
                return "Not Found";
            }
            await _gameRepository.DeleteAsync(entity);

            return $"Game com[leteluy delete";
        }

        public async Task<IEnumerable<GameDto>> GetAllAsync()
        {
            var entities = await _gameRepository.GetAll().ToListAsync();

            var dtos = entities.Select(e => new GameDto
            {
                Id = e.Id,
                Name = e.Name
            });

            return dtos;
        }
        public async Task<IEnumerable<GameEntity>> GetByGenreAsync(string genre)
        {
            var games = (await _gameRepository.GetByGenreAsync(genre)).ToList();

            var entities = games.Select(e => new GameEntity
            {
                Id = e.Id,
                Name = e.Name
            });
            
            return entities;

        }
        public async Task<GameDto> GetByIdAsync(string id)
        {
            var entity = await _gameRepository.GetByIdAsync(id);

            if(entity == null)
            {
                return null;
            }

            var dto = new GameDto
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return dto;

        }

        public async Task<string> UpdateAsync(UpdateGameDto dto)
        {
            if(await _gameRepository.IsExistsAsync(dto.Name))
            {
                return $"";
            }

            var entity = await _gameRepository.GetByIdAsync(dto.Id);

            if( entity == null)
            {
                return $"";
            }

            entity.Name = dto.Name;

            await _gameRepository.UpdateAsync(entity);

            return $"";
        }
    }
}
