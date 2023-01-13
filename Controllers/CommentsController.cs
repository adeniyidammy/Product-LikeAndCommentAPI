using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostAndCommentAPI.Dto;
using PostAndCommentAPI.Interface;
using PostAndCommentAPI.Models;

namespace PostAndCommentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly IComment _comment;
        private readonly IProduct _product;
        private readonly IMapper _mapper;
        public CommentsController(IComment comment, IMapper mapper, IProduct product)
        {
            _comment = comment;
            _product = product;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _comment.GetCommentsAsync();
            var result = _mapper.Map<List<CommentDto>>(comments);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);

        }

        [HttpGet("commentId")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            var check = await _comment.CheckIfCommentExist(commentId);
            if (!check)
            {
                return NotFound();
            }

            var comment = await _comment.GetCommentByIdAsync(commentId);
            var result = _mapper.Map<CreateGetCommentDto>(comment);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [HttpGet("{productId}/comment")]
        public async Task<IActionResult> GetCommentsOfAProduct(int productId)
        {
            var comment = await _comment.GetCommentsOfAProduct(productId);
            var result = _mapper.Map<List<CreateGetCommentDto>>(comment);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentAsync([FromQuery] int productID, [FromBody] CreateGetCommentDto createComm)
        {
            if (createComm == null)
            {
                return BadRequest(ModelState);
            }

            //var comment = await _comment.GetCommentsAsync();
            //var confirmName = comment.Where(c => c.Title.Trim().ToUpper() == createComm.Title.TrimEnd().ToUpper()).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commMap = _mapper.Map<Comment>(createComm);
            commMap.Product = await _product.GetProductbyIdAsync(productID);           

            if (!_comment.CreateCommentAsync(commMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Comment created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromQuery] int commentId, [FromBody] CommentDto updateComm)
        {
            if (updateComm == null)
            {
                return BadRequest(ModelState);
            }

            if (commentId != updateComm.Id)
            {
                return BadRequest(ModelState);
            }

            if (!await _comment.CheckIfCommentExist(commentId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commMap = _mapper.Map<Comment>(updateComm);
            if (!(_comment.UpdateCommentsAsync(commMap)))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var check = await _comment.CheckIfCommentExist(commentId);
            if (!check)
            {
                return NotFound();
            }

            var commentToDelete = await _comment.GetCommentByIdAsync(commentId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_comment.DeleteCommentAsync(commentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting !");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}

