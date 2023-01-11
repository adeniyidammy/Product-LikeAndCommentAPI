namespace PostAndCommentAPI.Models
{
    public class Commenter
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
