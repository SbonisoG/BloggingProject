using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
