using PostAndCommentAPI.Data;
using PostAndCommentAPI.Models;

namespace PostAndCommentAPI
{
    public class Seed
    {
        //private readonly ApplicationDbContext _context;
        //public Seed(ApplicationDbContext context)
        //{
        //    _context = context; 
        //}

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Contents.Any())
                {
                    context.Contents.AddRange(new List<Content>()
                    {

                        new Content()
                        {
                            PosterName = "Damilola",
                            ContentText = "This is an api for testing various comments.",
                            Comments = new List<Comment>()
                            {
                                new Comment { Title = "Damilola", CommentText = "Are you sure this is an api?", Like = true, Commenter = new Commenter() { FirstName = "Enyiuumin", Lastname = "Jiumin" } },
                                new Comment { Title = "Damilola", CommentText = "That's good of you", Like = true, Commenter = new Commenter() { FirstName = "Mancha", Lastname = "Pam" } },
                                new Comment { Title = "Damilola", CommentText = "Whaooo......", Like = false, Commenter = new Commenter() { FirstName = "Segun", Lastname = "Daniel" } }

                            }
                        },

                        new Content()
                        {
                            PosterName = "Sodiq",
                            ContentText = "You can as well use redux to build api.",
                            Comments = new List<Comment>()
                            {
                                new Comment { Title = "Sodiq", CommentText = "Thats good to hear", Like = true, Commenter = new Commenter() { FirstName = "Enyiuumin", Lastname = "Jiumin" } },
                                new Comment { Title = "Sodiq", CommentText = "Really...Really..", Like = true, Commenter = new Commenter() { FirstName = "Mancha", Lastname = "Pam" } },
                                new Comment { Title = "Sodiq", CommentText = "No, I don't think so.....", Like = false, Commenter = new Commenter() { FirstName = "Segun", Lastname = "Daniel" } }

                            }

                        }

                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
