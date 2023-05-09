using Blog.Domain.Dtos;
using Blog.Domain.Notifications;
using Blog.Shared;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Pe2Api.Domain.Entities.Base;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Domain.Entities
{
    public class Post : BaseEntity
    {

        public Post(string title, string content, string meta, string[] tags)
        {
            Title = title;
            Content = content;
            Meta = meta;
            Tags = tags;
            Slug = StringHelper.GenerateSlug(title);
        }

        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Meta { get; private set; }
        public string[] Tags { get; private set; }
        public string Slug { get; set; }
        public Thumbnail Thumbnail { get; private set; }

        public override void Validate()
        {
        }

        private static Thumbnail UploadImage(IFormFile image)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                });

            var host = builder.Build();

            var configuration = host.Services.GetService<IConfiguration>();

            Account account = new Account(
                configuration.GetSection("CloudinarySettings:CloudName").Value,
                configuration.GetSection("CloudinarySettings:ApiKey").Value,
                configuration.GetSection("CloudinarySettings:ApiSecret").Value);

            Cloudinary cloudinary = new Cloudinary(account);

            //Fazer o upload da imagem
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(image.FileName, image.OpenReadStream())
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            var teste = cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(340).Height(213).Crop("fill"));

            var thumbnail = new Thumbnail(teste.ToString(), uploadResult.PublicId);

            return thumbnail;
        }

        public static implicit operator Post(PostRequestDto dto)
        {
            var post = new Post(dto.Title, dto.Content, dto.Meta, dto.Tags);
            post.Thumbnail = UploadImage(dto.Image);

            return post;
        }


    }

    public class Thumbnail
    {
        public Thumbnail(string url, string publicId)
        {
            Url = url;
            PublicId = publicId;
        }

        public string Url { get; private set; }
        public string PublicId { get; private set; }
    }
}
