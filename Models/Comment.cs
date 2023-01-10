namespace PostAndCommentAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CommentText { get; set; }
        public bool Like { get; set; }
        public Content? Content { get; set; }
        public Commenter? Commenter { get; set; }   
    }
}
