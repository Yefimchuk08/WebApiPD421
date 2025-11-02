using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPD421.DAL.Entities;

namespace WebApiPD421.DAL.Repositories.Game
{
    public class GameRepository : GenericRepository<GameEntity, string>, IGameRepository
    {
        private readonly AppDbContext _context;
        public GameRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsExistsAsync(string name)
        {
            return await _context.Games
                .AnyAsync(g => g.Name == name.ToUpper());
        }
        public async Task<IEnumerable<GameEntity>> GetByGenreAsync(string genreName)
        {
            return await _context.Games
                .Include(g => g.Images) 
                .Include(g => g.Genres)  
                .Where(g => g.Genres.Any(
                    genre => genre.NormalizedName == genreName.ToUpper())) 
                .ToListAsync();
        }
    }
}
