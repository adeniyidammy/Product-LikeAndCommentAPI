using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostAndCommentAPI.Dto;
using PostAndCommentAPI.Interface;
using PostAndCommentAPI.Models;
using System.Diagnostics.Metrics;

namespace PostAndCommentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProduct _product;
        private readonly IMapper _mapper;
        public ProductsController(IProduct product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _product.GetProductsAsync();
            var result = _mapper.Map<List<ProductDto>>(products);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("{productId}")]

        public async Task<IActionResult> GetProductById(int productId)
        {
            var check = await _product.CheckIfProductExist(productId);
            if (!check)
            {
                return NotFound();
            }

            var product = await _product.GetProductbyIdAsync(productId);
            var result = _mapper.Map<CreateGetProductDto>(product);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);


        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateGetProductDto createProd)
        {
            if (createProd == null)
            {
                return BadRequest(ModelState);
            }

            var product = await _product.GetProductsAsync();
            var confirmName = product.Where(p => p.ProductName.Trim().ToUpper() == createProd.ProductName.TrimEnd().ToUpper()).FirstOrDefault();

            if (confirmName != null)
            {
                ModelState.AddModelError("", "Product already exists !");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productMap = _mapper.Map<Product>(createProd);
            if (!_product.CreateProductAsync(productMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Product created successfully");

        }

        [HttpPut]
        [Route("UpdateProduct/{productId}")]
        public async Task<IActionResult> UpdateProduct(/*[FromQuery] */int productId, [FromBody] UpdateProductDto updateProd)
        {
            var product = await _product.GetProductbyIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            _mapper.Map(updateProd, product);
            _product.Save();

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var check = await _product.CheckIfProductExist(productId);
            if (!check)
            {
                return NotFound();
            }

            var productToDelete = await _product.GetProductbyIdAsync(productId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_product.DeleteProductAsync(productToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting !");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpPost("Like/{productId}")]
        public async Task<IActionResult> Like(int productId)
        {
            var check = await _product.CheckIfProductExist(productId);
            if (!check)
            {
                return NotFound();
            }

            var likeProduct = await _product.GetProductbyIdAsync(productId);
            if (likeProduct == null)
            {
                return BadRequest(ModelState);
            }

            likeProduct.Like = true;
            _product.LikeProduct(likeProduct);

            return Ok("Product Liked succesfully!");

        }

        [HttpPost("Unlike/{productId}")]
        public async Task<IActionResult> Unlike(int productId)
        {
            var check = await _product.CheckIfProductExist(productId);
            if (!check)
            {
                return NotFound();
            }

            var unlikeProduct = await _product.GetProductbyIdAsync(productId);
            if (unlikeProduct == null)
            {
                return BadRequest(ModelState);
            }

            unlikeProduct.Like = false;
            _product.UpdateProductAsync(unlikeProduct);

            return Ok("You have successfully unlike the product!");
        }

        [HttpGet("LikedProducts")]
        public async Task<IActionResult> GetLikedProducts()
        {
            var likedProducts = await _product.GetLikedProductsAsync();
            var result = _mapper.Map<List<CreateGetProductDto>>(likedProducts);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }
    }
}
