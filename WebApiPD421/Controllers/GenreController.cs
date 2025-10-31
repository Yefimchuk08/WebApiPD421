using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] string name)
        {
            var entity = new GenreEntity
            {
                Name = name,
                NormalizedName = name.ToUpper()
            };

            await _genreRepository.CreateAsync(entity);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGenreRequest request)
        {
            var entity = await _genreRepository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return NotFound($"Жанр {request.Name} не знайдено");
            }
            entity.Name = request.Name;
            entity.NormalizedName = request.Name.ToUpper();

            await _genreRepository.UpdateAsync(entity);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _genreRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            await _genreRepository.DeleteAsync(entity);

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _genreRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _genreRepository.GetAll().ToListAsync();
            return Ok(entities);
        }
    }
}
