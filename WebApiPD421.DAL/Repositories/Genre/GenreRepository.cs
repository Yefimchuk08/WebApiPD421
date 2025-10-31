using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPD421.DAL.Entities;

namespace WebApiPD421.DAL.Repositories.Genre
{
    public class GenreRepository : GenericRepository<GenreEntity, string>, IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context) { }
    }
}
