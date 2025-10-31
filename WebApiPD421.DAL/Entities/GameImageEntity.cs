using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.DAL.Entities
{
    public class GameImageEntity : BaseEntity<string>
    {
        public required string ImagePath { get; set; }
        public bool IsMain { get; set; } = false;
        public string GameId { get; set; }
        public GameEntity? Game { get; set; }
    }
}
