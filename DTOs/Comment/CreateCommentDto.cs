using System.ComponentModel.DataAnnotations;

namespace finance.api.DTOs.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "超出长度")]
        [MinLength(1, ErrorMessage = "至少1个字符")]
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int StockId { get; set; }
    }
}
