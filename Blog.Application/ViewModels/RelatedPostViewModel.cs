using Blog.Domain.Entities;

namespace Blog.Application.ViewModels
{
    public class RelatedPostViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Meta { get; set; }

        public static implicit operator RelatedPostViewModel(Post post)
        {
            return new RelatedPostViewModel { Id = post.Id, Title = post.Title, Meta = post.Meta };
        }
    }
}
