using Blog.Domain.Entities;

namespace Blog.Application.ViewModels
{
    public class PostResponseViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Meta { get; set; }
        public string[] Tags { get; set; }
        public string Slug { get; set; }
        public string Thumbnail { get; set; }
        public DateTime CreatedAt { get; set; }

        public static implicit operator PostResponseViewModel (Post post)
        {
            return new PostResponseViewModel()
            {
                Id = post.Id,   
                Title = post.Title,
                Content = post.Content,
                Meta = post.Meta,
                Tags = post.Tags,
                Slug = post.Slug,
                Thumbnail = post.Thumbnail,
                CreatedAt = post.CreatedAt
            };
        }
           
    }
}
