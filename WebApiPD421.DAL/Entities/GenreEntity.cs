using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.DAL.Entities
{
    public class GenreEntity : BaseEntity<string>
    {
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public string? NormalizedName { get; set; }
        public ICollection<GameEntity> Games { get; set; } = [];
    }
}
