using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.BLL.Dtos.Genre
{
    public class CreateGenreDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
