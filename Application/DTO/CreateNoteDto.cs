using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateNoteDto
    {
        [Required]
        public string Content { get; set; }
    }
}
