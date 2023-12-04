namespace test.api.models.DTOs
{
    public class regionsdto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string? RegionImgUrl { get; set; }

        internal static void Add(regionsdto regionsdto)
        {
            throw new NotImplementedException();
        }
    }
}
