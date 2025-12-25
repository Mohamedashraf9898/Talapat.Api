using System.ComponentModel.DataAnnotations;

namespace Talapat.Api.Dtos
{
    public class LogInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string password { get; set; } = null!;
    }
}
