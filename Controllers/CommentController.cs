using finance.api.DTOs.Comment;
using finance.api.Interfaces;
using finance.api.Mappers;
using finance.api.Models;
using finance.api.Repository;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace finance.api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;
        private readonly IStockRepository stockRepository;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            this.commentRepository = commentRepository;
            this.stockRepository = stockRepository;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CommentGetAllQuery query)
        {
            var commentModels = await commentRepository.GetAllAsyn(query);
            var commentDtos = commentModels.Select(v => v.ToDto());
            return Ok(commentDtos);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var model = await commentRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var dto = model.ToDto();
            return Ok(dto);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await stockRepository.IsExistAsync(dto.StockId)) return BadRequest();
            var model = await commentRepository.CreateAsync(dto.ToModel());

            return CreatedAtAction(nameof(Get), new { id = model.Id }, model.ToDto());
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentDto dto)
        {
            var model = await commentRepository.UpdateAsync(id, dto.ToModel());
            if (model == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await commentRepository.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
