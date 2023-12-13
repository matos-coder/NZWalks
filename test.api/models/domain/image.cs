using System.ComponentModel.DataAnnotations.Schema;

namespace test.api.models.domain
{
    public class image
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public long FileSizeInByte { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
    }
}
