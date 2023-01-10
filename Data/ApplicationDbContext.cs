using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Content>? Contents { get; set; }    
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Commenter>? Commenters { get; set; }
    }
}
