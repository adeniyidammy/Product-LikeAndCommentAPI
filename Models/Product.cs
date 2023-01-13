using System.ComponentModel.DataAnnotations;

namespace PostAndCommentAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }    
        public DateTime ProductDate { get; set; }
        public string? ProductDescription { get; set; }
        public bool Like { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
