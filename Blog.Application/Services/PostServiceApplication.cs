
using Blog.Application.Pagination;
using Blog.Application.Services.Base;
using Blog.Application.ViewModels;
using Blog.Domain.Dtos;
using Blog.Domain.Entities;
using Blog.Domain.Notifications;
using Blog.Domain.Repositories;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application.Services
{
    public class PostServiceApplication : BaseServiceApplication, IPostServiceApplication
    {
        private readonly IPostWriteRepository _writeRepository;
        private readonly IPostReadRepository _postReadRepository;
        private readonly IConfiguration _configuration;
        public PostServiceApplication(
            NotificationContext notificationContext,
            IPostWriteRepository writeRepository,
            IPostReadRepository postReadRepository,
            IConfiguration configuration) : base(notificationContext)
        {
            _writeRepository = writeRepository;
            _postReadRepository = postReadRepository;
            _configuration = configuration;
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

        public async Task DeleteOneAsync(Guid id)
        {
            var post = await _postReadRepository.FindByIdAsync(id);
            if (post is null)
            {
                _notificationContext.AddNotification("Error", "Post does not exist");
                return;
            }

            await _writeRepository.DeleteByIdAsync(id);
        }

        public async Task<ThumbnailViewModel> UploadImage(IFormFile image)
        {
            var cloudName = _configuration.GetSection("CloudinarySettings:CloudName").Value;
            var apiKey = _configuration.GetSection("CloudinarySettings:ApiKey").Value;
            var apiSecret = _configuration.GetSection("CloudinarySettings:ApiSecret").Value;

            Account account = new Account(cloudName, apiKey, apiSecret);

            Cloudinary cloudinary = new Cloudinary(account);

            //Fazer o upload da imagem
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(image.FileName, image.OpenReadStream())
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            var thumbnail = new ThumbnailViewModel(uploadResult.SecureUrl.ToString(), uploadResult.PublicId);

            return thumbnail;
        }

        public async Task<PostResponseViewModel> GetBySlugAsync(string slug)
        {
            var post = await _postReadRepository.FindOneAsync(p => p.Slug == slug);

            var postNotFound = post is null;
            if (postNotFound)
            {
                _notificationContext.AddNotification("Error", "Post not found");
                return default;
            }

            return post;

        }

        public async Task<PaginationResponse<Post>> GetAllByTagAsync(int currentPage, int quantityPerPage, string tag)
        {
            var (posts, totalRecords) = await _postReadRepository.FindAllPaginatedAsync(currentPage, quantityPerPage, p => p.Tag == tag);

            return new PaginationResponse<Post>(currentPage, quantityPerPage, totalRecords, posts);

        }


    }
}
