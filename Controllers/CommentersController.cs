//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using PostAndCommentAPI.Dto;
//using PostAndCommentAPI.Interface;
//using PostAndCommentAPI.Models;

//namespace PostAndCommentAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CommentersController : Controller
//    {
//        private readonly ICommenter _commenter;
//        private readonly IMapper _mapper;
//        public CommentersController(ICommenter commenter, IMapper mapper)
//        {
//            _commenter = commenter;
//            _mapper = mapper;   
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetCommenters()
//        {
//            var commenters = await _commenter.GetCommentersAsync();
//            var result = _mapper.Map<List<CommentersDto>>(commenters);

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            return Ok(result);
//        }

//        [HttpGet("commenterId")]
//        public async Task<IActionResult> GetCommenterById(int commenterId)
//        {
//            var check = await _commenter.CheckIfCommenterExists(commenterId);
//            if (!check)
//            {
//                return NotFound();
//            }

//            var commenter = await _commenter.GetCommenterByIdAsync(commenterId);
//            var result = _mapper.Map<CommentersDto>(commenter);

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            return Ok(result);
//        }

//        [HttpGet("{commenterId}/comments")]
//        public async Task<IActionResult> GetCommentsByCommenter(int commenterId)
//        {
//            var check = await _commenter.CheckIfCommenterExists(commenterId);
//            if (!check)
//            {
//                return NotFound();
//            }

//            var comments = await _commenter.GetCommentsByCommenterAsync(commenterId);
//            var result = _mapper.Map<List<CommentDto>>(comments);

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            return Ok(result);
            
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateCommenter([FromBody] CommentersDto createCommenter)
//        {
//            if(createCommenter == null)
//            {
//                return BadRequest(ModelState);
//            }

//            var commenters = await _commenter.GetCommentersAsync();
//            var confirmName = commenters.Where(c => c.FirstName.Trim().ToUpper() == createCommenter.FirstName.TrimEnd().ToUpper()).FirstOrDefault();

//            if (confirmName != null)
//            {
//                ModelState.AddModelError("", "A Commenter already exists !");
//                return StatusCode(422, ModelState);
//            }

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var commenterMap = _mapper.Map<Commenter>(createCommenter);
//            if (!_commenter.CreateCommenterAsync(commenterMap))
//            {
//                ModelState.AddModelError("", "Something went wrong while saving!");
//                return StatusCode(500, ModelState);
//            }

//            return Ok("A Commenter is created successfully");


//        }


//        [HttpPut]
//        public async Task<IActionResult> UpdateCommenter([FromQuery] int commenterId, [FromBody] CommentersDto updateCommenter)
//        {
//            if (updateCommenter == null)
//            {
//                return BadRequest(ModelState);
//            }

//            //if (commenterId != updateCommenter.Id)
//            //{
//            //    return BadRequest(ModelState);
//            //}

//            if (!await _commenter.CheckIfCommenterExists(commenterId))
//            {
//                return NotFound();
//            }

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var commenterMap = _mapper.Map<Commenter>(updateCommenter);
//            if (!(_commenter.UpdateCommentAsync(commenterMap)))
//            {
//                ModelState.AddModelError("", "Something went wrong while updating");
//                return StatusCode(500, ModelState);
//            }

//            return Ok("Commenter Updated Successfully");
//        }

//        [HttpDelete]
//        public async Task<IActionResult> DeleteCommenter(int commenterId)
//        {
//            var check = await _commenter.CheckIfCommenterExists(commenterId);
//            if (!check)
//            {
//                return NotFound();
//            }

//            var commenterToDelete = await _commenter.GetCommenterByIdAsync(commenterId);

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (!_commenter.DeleteCommenterAsync(commenterToDelete))
//            {
//                ModelState.AddModelError("", "Something went wrong while deleting !");
//                return StatusCode(500, ModelState);
//            }

//            return Ok("Commenter Deleted Successfully");

//        }
//    }
//}
