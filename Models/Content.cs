namespace PostAndCommentAPI.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string? PosterName { get; set; }
        public string? ContentText { get; set; }
        public ICollection<Comment>? Comments { get; set; }
       
    }
}
