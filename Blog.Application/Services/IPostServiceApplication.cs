using Blog.Application.Pagination;
using Blog.Application.ViewModels;
using Blog.Domain.Dtos;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services
{
    public interface IPostServiceApplication
    {
        public Task CreateAsync(PostRequestDto dto);
        public Task<PaginationResponse<Post>> GetAllAsync(int currentPage, int quantityPerPage);
        public Task<PostResponseViewModel> GetBySlugAsync(string slug);
        public Task DeleteOneAsync(Guid id);
        public Task<ThumbnailViewModel> UploadImage(IFormFile image);


    }
}
