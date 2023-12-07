using System.ComponentModel.DataAnnotations;

namespace test.api.models.DTOs
{
    public class addRegionDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "min caracter is 3")]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        public string? RegionImgUrl { get; set; }
    }
}
