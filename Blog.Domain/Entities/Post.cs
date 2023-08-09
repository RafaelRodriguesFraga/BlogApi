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

        public Post(string title, string content, string meta, string tag, string thumbnail)
        {
            Title = title;
            Content = content;
            Meta = meta;
            Tag = tag;
            Slug = StringHelper.GenerateSlug(title);
            Thumbnail = thumbnail;
        }

        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Meta { get; private set; }
        public string Tag { get; private set; }
        public string Slug { get; set; }
        public string Thumbnail { get; private set; }

        public override void Validate()
        {
        }

       

        public static implicit operator Post(PostRequestDto dto)
        {
            var post = new Post(dto.Title.Trim(), dto.Content.Trim(), dto.Meta.Trim(), dto.Tag, dto.Thumbnail);

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
