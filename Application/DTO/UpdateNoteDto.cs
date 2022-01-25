using System.ComponentModel.DataAnnotations;

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
