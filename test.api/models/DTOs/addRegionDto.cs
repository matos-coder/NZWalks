using System.ComponentModel.DataAnnotations;

namespace test.api.models.DTOs
{
    public class addRegionDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        public string? RegionImgUrl { get; set; }
    }
}
