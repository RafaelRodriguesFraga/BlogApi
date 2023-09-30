using Blog.Application.ViewModels;
using Blog.Domain.Dtos;
using Blog.Domain.Entities;
using DotnetBoilerplate.Components.Application.Pagination;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services
{
    public interface IPostServiceApplication
    {
        public Task CreateAsync(PostRequestDto dto);
        public Task<PaginationResponse<Post>> GetAllAsync(int currentPage, int quantityPerPage);
        public Task<PaginationResponse<Post>> GetAllByTagAsync(int currentPage, int quantityPerPage, string tag);
        public Task<PostResponseViewModel> GetBySlugAsync(string slug);
        public Task<IEnumerable<PostResponseViewModel>> SearchByTitleAsync(string title);
        public Task DeleteOneAsync(Guid id);
        public Task<ThumbnailViewModel> UploadImage(IFormFile image);
        public Task<IEnumerable<RelatedPostViewModel>> GetRelatedPostsAsync(Guid id, string tag);


    }
}
