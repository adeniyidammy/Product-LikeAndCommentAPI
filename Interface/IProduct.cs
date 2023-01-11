using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Interface
{
    public interface IProduct
    {
        Task <ICollection<Product>> GetProductsAsync();
        Task<Product> GetProductbyIdAsync(int productId);
        Task<bool> CheckIfProductExist(int ProductId);
        bool CreateProductAsync(Product product); 
        bool UpdateProductAsync(Product product);   
        bool DeleteProductAsync(Product product);
        bool Save();



    }
}
