using System.ComponentModel.DataAnnotations;

namespace PostAndCommentAPI.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }       
        public string? Title { get; set; }    
        public string? CommentText { get; set; }
    }

    public class CreateGetCommentDto
    {
        public string? Title { get; set; }
        public string? CommentText { get; set; }
    }
    public class UpdateCommentDto
    {
        public string? Title { get; set; }
        public string? CommentText { get; set; }
    }
}
