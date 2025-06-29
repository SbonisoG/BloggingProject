using System.ComponentModel.DataAnnotations;

namespace BloggingProject.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(200, ErrorMessage = " Do not exceed 200 letters")]

        public required string Name { get; set; }
        [MaxLength(650, ErrorMessage = " Do not exceed 200 letters")]

        public string? Description { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
