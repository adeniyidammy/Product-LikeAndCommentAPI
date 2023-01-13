using Microsoft.EntityFrameworkCore;
using PostAndCommentAPI.Data;
using PostAndCommentAPI.Interface;
using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Repository
{
    public class CommentRepository : IComment
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckIfCommentExist(int commentId)
        {
            var result = await _context.Comments.AnyAsync(x => x.Id == commentId);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool CreateCommentAsync(Comment comment)
        {
            _context.Add(comment);
            return Save();
        }

        public bool DeleteCommentAsync(Comment comment)
        {
            _context.Remove(comment);
            return Save();
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
        }

        public async Task<ICollection<Comment>> GetCommentsOfAProduct(int productId)
        {
            return await _context.Comments.Where(x => x.Product.Id == productId).ToListAsync();
        }

        public async Task<ICollection<Comment>> GetCommentsAsync()
        {
            return await _context.Comments.OrderBy(x => x.Id).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCommentsAsync(Comment comment)
        {
            _context.Update(comment);
            return Save();
        }

     
    }
}
