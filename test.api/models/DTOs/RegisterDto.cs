using System.ComponentModel.DataAnnotations;

namespace test.api.models.DTOs
{
    public class RegisterDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] roles { get; set; }
    }
}
