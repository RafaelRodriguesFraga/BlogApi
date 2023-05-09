namespace Blog.Application.ViewModels
{
    public class PostRequestViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Meta { get; set; }
        public string[] Tags { get; set; }
        public string Slug { get; set; }
        public ThumbnailViewModel Thumbnail { get; set; }
    }
}
