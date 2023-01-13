using System.ComponentModel.DataAnnotations;

namespace PostAndCommentAPI.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductDate { get; set; }
        public string? ProductDescription { get; set; }
    }

    public class CreateGetProductDto
    {
        public string? ProductName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductDate { get; set; }
        public string? ProductDescription { get; set; }
    }
}
