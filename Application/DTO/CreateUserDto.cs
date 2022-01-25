using System.ComponentModel.DataAnnotations;


namespace Application.DTO
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(6)]
        [MaxLength(25)]
        public string Login { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(25)]
        public string Password { get; set; }
    }
}
