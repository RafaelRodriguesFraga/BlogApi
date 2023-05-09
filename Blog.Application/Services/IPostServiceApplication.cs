using Blog.Application.ViewModels;
using Blog.Domain.Dtos;

namespace Blog.Application.Services
{
    public interface IPostServiceApplication
    {
        public Task CreateAsync(PostRequestDto dto);

    }
}
