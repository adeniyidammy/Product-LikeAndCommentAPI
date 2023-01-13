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

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {

                        new Product()
                        {
                            ProductName = "HP EliteBook 2560P",
                            ProductDate = new DateTime(2002,9,7),
                            ProductDescription = "This is a good pc.",
                            Like = true,
                            Comments = new List<Comment>()
                            {
                                new Comment { Title = "HP EliteBook 2560P", CommentText = "Are you sure this pc is good?", Commenter = new Commenter() { FirstName = "Enyiuumin", Lastname = "Jiumin" } },
                                new Comment { Title = "HP EliteBook 2560P", CommentText = "That's a good product", Commenter = new Commenter() { FirstName = "Mancha", Lastname = "Pam" } },
                                new Comment { Title = "HP EliteBook 2560P", CommentText = "Whaooo......I don't like this product", Commenter = new Commenter() { FirstName = "Segun", Lastname = "Daniel" } }

                            },
                            
                                                     
                        },

                        new Product()
                        {
                            ProductName = "Dell Premium",
                            ProductDate = new DateTime(2022,2,10),
                            ProductDescription = "This PC is core I5, and has 16GB of RAM.",
                            Like= false,
                            Comments = new List<Comment>()
                            {
                                new Comment { Title = "Dell Premium", CommentText = "Thats good to hear", Commenter = new Commenter() { FirstName = "Enyiuumin", Lastname = "Jiumin" } },
                                new Comment { Title = "Dell Premium", CommentText = "Really...Really..", Commenter = new Commenter() { FirstName = "Mancha", Lastname = "Pam" } },
                                new Comment { Title = "Dell Premium", CommentText = "No, I don't think so.....", Commenter = new Commenter() { FirstName = "Segun", Lastname = "Daniel" } }

                            },

                          
                        }

                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
