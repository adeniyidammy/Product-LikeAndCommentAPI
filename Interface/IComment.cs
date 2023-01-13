using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Interface
{
    public interface IComment
    {
        Task <ICollection<Comment>> GetCommentsAsync();
        bool UpdateCommentsAsync(Comment comment);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task <ICollection<Comment>>GetCommentsOfAProduct(int productId);
        bool DeleteCommentAsync(Comment comment);
        bool CreateCommentAsync(Comment comment);
        Task<bool> CheckIfCommentExist(int commentId);

        bool Save();

       
    }
}
