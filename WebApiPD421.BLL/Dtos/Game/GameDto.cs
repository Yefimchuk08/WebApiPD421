using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.BLL.Dtos.Game
{
    public class GameDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? RealizeDate { get; set; }
        public double? Price { get; set; }
        public string? Publisher { get; set; }
        public string? Developer { get; set; }
        public string? Category { get; set; }
    }
}
