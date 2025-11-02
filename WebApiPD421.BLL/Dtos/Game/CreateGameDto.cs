using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.BLL.Dtos.Game
{
    public class CreateGameDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required double Price { get; set; }
        [Required]
        public required DateTime RealizeDate { get; set; }
        [Required]
        public required string Publisher { get; set; }
        [Required]
        public required string Developer { get; set; }
        [Required]
        public required string Category { get; set; }
    }
}
