using Microsoft.EntityFrameworkCore;
using PostAndCommentAPI.Data;
using PostAndCommentAPI.Interface;
using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Repository
{
    public class CommenterRepository : ICommenter
    {
        private readonly ApplicationDbContext _context;
        public CommenterRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckIfCommenterExists(int commenterId)
        {
            return await _context.Commenters.AnyAsync(x => x.Id == commenterId);
        }

        public bool CreateCommenterAsync(Commenter commenter)
        {
            _context.Add(commenter);
            return Save();
        }

        public bool DeleteCommenterAsync(Commenter commenter)
        {
            _context.Remove(commenter);
            return Save();
        }

        public async Task<Commenter> GetCommenterByIdAsync(int commenterId)
        {
            return await _context.Commenters.FirstOrDefaultAsync(x => x.Id == commenterId);
        }

        public async Task<ICollection<Commenter>> GetCommentersAsync()
        {
            return await _context.Commenters.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<ICollection<Comment>> GetCommentsByCommenterAsync(int commenterId)
        {
            return await _context.Comments.Where(x => x.Commenter.Id == commenterId).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //public Task SaveChanges()
        //{
        //    return _context.SaveChangesAsync();
        //}

        public bool UpdateCommentAsync(Commenter commenter)
        {
            _context.Update(commenter);
            return Save();
        }
    }
}
