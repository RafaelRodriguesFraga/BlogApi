using Blog.Api.Base;
using Blog.Api.Responses;
using Blog.Application.Services;
using Blog.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ApiControllerBase
    {
        private readonly IPostServiceApplication _postServiceApplication;
     
        public PostController(IResponseFactory responseFactory, IPostServiceApplication postServiceApplication) : base(responseFactory)
        {
            _postServiceApplication = postServiceApplication;
        }

        /// <summary>
        /// Creates a post
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>A valid post</returns>
        /// <response code="201">Returns Created if a post is succefully created</response>
        /// <response code="400">Returns BadRequest if there's any validation errors</response>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] PostRequestDto dto)
        {
            await _postServiceApplication.CreateAsync(dto);

            return ResponseCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int currentPage, [FromQuery] int quantityPerPage)
        {
            var result = await _postServiceApplication.GetAllAsync(currentPage, quantityPerPage);

            return ResponseOk(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _postServiceApplication.DeleteOneAsync(id);

            return CreateResponse();
        }
    }
}
