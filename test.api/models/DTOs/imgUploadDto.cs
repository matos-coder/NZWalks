using System.ComponentModel.DataAnnotations;

namespace test.api.models.DTOs
{
    public class imgUploadDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }

    }
}
