using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Interface
{
    public interface ICommenter
    {
        Task<ICollection<Commenter>> GetCommentersAsync();
        Task<Commenter> GetCommenterByIdAsync(int commenterId);
        Task<Comment> GetCommentsByCommenterAsync(int commenterId);
        Task<bool> CheckIfCommenterExists(int commenterId);
        bool CreateCommenterAsync(Commenter commenter);
        bool UpdateCommentAsync(Commenter commenter);
        bool DeleteCommenterAsync(Commenter commenter);
        bool Save();

    }
}
