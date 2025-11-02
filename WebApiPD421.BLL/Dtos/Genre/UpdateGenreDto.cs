using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.BLL.Dtos.Genre
{
    public class UpdateGenreDto
    {
        [Required]
        public required string Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
