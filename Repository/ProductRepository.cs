using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostAndCommentAPI.Data;
using PostAndCommentAPI.Interface;
using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
                _context = context;
        }
        public async Task<bool> CheckIfProductExist(int ProductId)
        {
            var result = await _context.Products.AnyAsync(x => x.Id == ProductId);

            if (result) return true;
            return false;
        }

        public bool CreateProductAsync(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool DeleteProductAsync(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public async Task<Product> GetProductbyIdAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return await _context.Products.OrderBy(x => x.Id).ToListAsync();
        }

        public bool LikeProduct(Product product)
        {
            _context.Update(product);
            return Save();
        }
        public bool UnikeProduct(Product product)
        {
            _context.Update(product);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }

        public bool UpdateProductAsync(Product product)
        {
            _context.Update(product);
            return Save();
        }

        public async Task<ICollection<Product>> GetLikedProductsAsync()
        {
            return await _context.Products.Where(x => x.Like == true).ToListAsync();
        }
    }
}
