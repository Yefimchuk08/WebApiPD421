using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebApiPD421.DAL.Entities;
using WebApiPD421.DAL.Repositories;
using WebApiPD421.DAL.Repositories.Game;

namespace WebApiPD421.Controllers
{
    public class UpdateGameRequest
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required DateTime RelizedDate { get; set; }
        public required string Publisher {  get; set; }
        public required string Developer { get; set; }
        public required string Category { get; set; }


    }

    [ApiController]
    [Route("api/game")]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UpdateGameRequest request)
        {
            var entity = new GameEntity
            {
                Name = request.Name,
                Price = request.Price,
                RealizeDate = request.RelizedDate,
                Publisher = request.Publisher,
                Developer = request.Developer,
                Category = request.Category
            };


            await _gameRepository.CreateAsync(entity);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGameRequest request)
        {
            var entity = await _gameRepository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return NotFound($"Жанр {request.Name} не знайдено");
            }
            entity.Name = request.Name;
            entity.Price = request.Price;
            entity.RealizeDate  = request.RelizedDate;
            entity.Publisher = request.Publisher;
            entity.Developer = request.Developer;
            entity.Category = request.Category;

            await _gameRepository.UpdateAsync(entity);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _gameRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            await _gameRepository.DeleteAsync(entity);

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _gameRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _gameRepository.GetAll().ToListAsync();
            return Ok(entities);
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetByCategory(string categoryName)
        {
            var games = await _gameRepository.GetByCategoryAsync(categoryName);

            if (!games.Any())
                return NotFound($"Ігор у категорії '{categoryName}' не знайдено.");

            return Ok(games);
        }
    }
}
