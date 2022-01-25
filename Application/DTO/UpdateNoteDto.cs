using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UpdateNoteDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }

    }
}
