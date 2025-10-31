using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.DAL.Entities
{
    public class GameEntity : BaseEntity<string>
    {
        public override string Id { get ; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        public DateTime RealizeDate { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Category { get; set; }
        public ICollection<GenreEntity> Genres { get; set; } = [];
        public ICollection<GameImageEntity> Images { get; set; } = [];
    }
}
