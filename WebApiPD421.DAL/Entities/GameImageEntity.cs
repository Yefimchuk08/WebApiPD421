using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.DAL.Entities
{
    public class GameImageEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string ImagePath { get; set; }
        public bool IsMain { get; set; } = false;
        public string GameId { get; set; }
        public GameEntity? Game { get; set; }
    }
}
