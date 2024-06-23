namespace API.DTO.Comment
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = string.Empty;
        public int? StockId { get; set; }
    }
}