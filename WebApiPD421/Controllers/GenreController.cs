using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebApiPD421.BLL.Dtos.Genre;
using WebApiPD421.BLL.Services.Genre;
using WebApiPD421.DAL.Entities;
using WebApiPD421.DAL.Repositories.Genre;

namespace WebApiPD421.Controllers
{
    public class UpdateGenreRequest
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
    }

    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGenreDto dto)
        {
            var response = await _genreService.CreateAsync(dto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGenreDto dto)
        {
            var response = await _genreService.UpdateAsync(dto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id не вказано");
            }

            var response = await _genreService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id не вказано");
            }

            var response = await _genreService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _genreService.GetAllAsync();
            return Ok(response);
        }
    }
}
