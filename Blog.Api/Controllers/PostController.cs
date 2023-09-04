using Blog.Application.Services;
using Blog.Application.ViewModels;
using Blog.Domain.Dtos;
using DotnetBoilerplate.Components.Api.Base;
using DotnetBoilerplate.Components.Api.Responses;
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
        public async Task<IActionResult> CreateAsync(PostRequestDto dto)
        {
            await _postServiceApplication.CreateAsync(dto);

            return ResponseCreated();
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImageAsync([FromForm] ThumbnailRequestViewModel viewModel)
        {
            var result = await _postServiceApplication.UploadImage(viewModel.File);

            return ResponseOk(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int currentPage, [FromQuery] int quantityPerPage)
        {
            var result = await _postServiceApplication.GetAllAsync(currentPage, quantityPerPage);

            return ResponseOk(result);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetBySlugAsync([FromRoute] string slug)
        {
            var result = await _postServiceApplication.GetBySlugAsync(slug);

            return ResponseOk(result);
        }

        [HttpGet("tag/{tag}")]
        public async Task<IActionResult> GetAllByTagAsync([FromQuery] int currentPage, [FromQuery] int quantityPerPage, [FromRoute] string tag)
        {
            var result = await _postServiceApplication.GetAllByTagAsync(currentPage, quantityPerPage, tag);

            return ResponseOk(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByTitleAsync([FromQuery] string title)
        {
            var result = await _postServiceApplication.SearchByTitleAsync(title);

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
