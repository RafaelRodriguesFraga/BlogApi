
using Blog.Application.Services.Base;
using Blog.Domain.Dtos;
using Blog.Domain.Notifications;
using Blog.Domain.Repositories;

namespace Blog.Application.Services
{
    public class PostServiceApplication : BaseServiceApplication, IPostServiceApplication
    {
        private readonly IPostWriteRepository _writeRepository;
         public PostServiceApplication(NotificationContext notificationContext, IPostWriteRepository writeRepository) : base(notificationContext)
        {
            _writeRepository = writeRepository;
        }


        public async Task CreateAsync(PostRequestDto dto)
        {         
            
            await _writeRepository.InsertOneAsync(dto);
        }

      
    }
}
