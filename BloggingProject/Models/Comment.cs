using System.ComponentModel.DataAnnotations;

namespace BloggingProject.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [MaxLength(250, ErrorMessage = " Do not exceed 200 letters")]
        public required string UserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }
        [MaxLength(1050, ErrorMessage = " Do not exceed 200 letters")]
        public required string CommentContent { get; set; }
    }
}
