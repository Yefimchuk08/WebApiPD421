using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Net;
using WebApiPD421.BLL.Dtos.Game;
using WebApiPD421.BLL.Dtos.Genre;
using WebApiPD421.BLL.Services;
using WebApiPD421.BLL.Services.Game;
using WebApiPD421.DAL.Entities;
using WebApiPD421.DAL.Repositories;
using WebApiPD421.DAL.Repositories.Game;
using WebApiPD421.Extentions;

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
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGameDto dto)
        {
            var response = await _gameService.CreateAsync(dto);
            return this.ToActionResult(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGameDto dto)
        {
            var response = await _gameService.UpdateAsync(dto);
            return this.ToActionResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var validResponse = new ServiceResponse
                {
                    Message = "Id не вказано",
                    IsSuccess = false,
                    HttpStatusCode = HttpStatusCode.BadRequest
                };
                return this.ToActionResult(validResponse);

            }

            var response = await _gameService.DeleteAsync(id);
            return this.ToActionResult(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id не вказано");
            }

            var response = await _gameService.GetByIdAsync(id);
            return this.ToActionResult(response);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _gameService.GetAllAsync();
            return this.ToActionResult(response);
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetByCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return BadRequest("Category не вказано");
            }

            var response = await _gameService.GetByGenreAsync(categoryName);
            return this.ToActionResult(response);
        }
    }
}
