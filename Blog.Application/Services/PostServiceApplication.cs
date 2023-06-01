
using Blog.Application.Pagination;
using Blog.Application.Services.Base;
using Blog.Application.ViewModels;
using Blog.Domain.Dtos;
using Blog.Domain.Entities;
using Blog.Domain.Notifications;
using Blog.Domain.Repositories;

namespace Blog.Application.Services
{
    public class PostServiceApplication : BaseServiceApplication, IPostServiceApplication
    {
        private readonly IPostWriteRepository _writeRepository;
        private readonly IPostReadRepository _postReadRepository;
        public PostServiceApplication(
            NotificationContext notificationContext,
            IPostWriteRepository writeRepository,
            IPostReadRepository postReadRepository) : base(notificationContext)
        {
            _writeRepository = writeRepository;
            _postReadRepository = postReadRepository;
        }


        public async Task CreateAsync(PostRequestDto dto)
        {         
            
            await _writeRepository.InsertOneAsync(dto);
        }

        public async Task<PaginationResponse<Post>> GetAllAsync(int currentPage, int quantityPerPage)
        {
            var (posts, totalRecords) = await _postReadRepository.FindAllPaginatedAsync(currentPage, quantityPerPage);

            return new PaginationResponse<Post>(currentPage, quantityPerPage, totalRecords, posts);
        }
    }
}
