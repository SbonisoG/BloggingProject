using System.ComponentModel.DataAnnotations;

namespace BloggingProject.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [MaxLength(200, ErrorMessage =" Do not exceed 200 letters")]
        public required string Title { get; set; }
        [MaxLength(20000, ErrorMessage = " Do not exceed 200 letters")]
        public required string Content { get; set; }
        [MaxLength(150, ErrorMessage = " Do not exceed 200 letters")]
        public required string Author { get; set; }
        public required string imagePath { get; set; }
        [DataType(DataType.Date)]
        public required DateTime PublishedDate { get; set; } = DateTime.Now;
    }
}
