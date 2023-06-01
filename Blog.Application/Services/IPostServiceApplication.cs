using Blog.Application.Pagination;
using Blog.Application.ViewModels;
using Blog.Domain.Dtos;
using Blog.Domain.Entities;

namespace Blog.Application.Services
{
    public interface IPostServiceApplication
    {
        public Task CreateAsync(PostRequestDto dto);
        public Task<PaginationResponse<Post>> GetAllAsync(int currentPage, int quantityPerPage); 

    }
}
