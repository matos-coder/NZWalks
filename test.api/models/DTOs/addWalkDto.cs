namespace test.api.models.DTOs
{
    public class addWalkDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImgUrl { get; set; }

        public Guid difficultyId { get; set; }

        public Guid regionId { get; set; }
    }
}
