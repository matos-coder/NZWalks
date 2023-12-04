namespace test.api.models.domain
{
    public class walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImgUrl { get; set; }

        public Guid difficultyId { get; set; }

        public Guid regionId { get; set; }

        //nav property

        public difficulty difficulty { get; set; }
        
        public region region { get; set; }
    }
}
 