using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Interface
{
    public interface IComment
    {
        Task <ICollection<Comment>> GetCommentsAsync();
        bool UpdateCommentsAsync(Comment comment);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<Comment> GetCommentOfProducts(int productId);
        bool DeleteCommentAsync(Comment comment);
        bool CreateCommentAsync(Comment comment);
        Task<bool> CheckIfCommentExist(int commentId);
       
    }
}
