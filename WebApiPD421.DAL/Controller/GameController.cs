using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPD421.DAL.Entities;

namespace WebApiPD421.DAL.Controller
{
    public class GameController
    {
        private readonly AppDbContext _context;
        public GameController(AppDbContext context)
        {
            _context = context;
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

        public async Task<GameEntity> CreateAsync(GameEntity game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        
        public async Task<IEnumerable<GameEntity>> GetAllAsync()
        {
            return await _context.Games
                .Include(g => g.Genres)
                .Include(g => g.Images)
                .ToListAsync();
        }

     
        public async Task<GameEntity?> GetByIdAsync(string id)
        {
            return await _context.Games
                .Include(g => g.Genres)
                .Include(g => g.Images)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        
        public async Task<bool> UpdateAsync(GameEntity game)
        {
            var existing = await _context.Games.FindAsync(game.Id);
            if (existing == null)
                return false;

            
            existing.Name = game.Name;
            existing.Description = game.Description;
            existing.Price = game.Price;
            existing.Developer = game.Developer;
            existing.Publisher = game.Publisher;

            _context.Games.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        
        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return false;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
