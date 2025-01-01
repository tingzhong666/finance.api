namespace finance.api.DTOs.Comment
{
    public class UpdateCommentDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? StockId { get; set; }
    }
}
