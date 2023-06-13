using Microsoft.AspNetCore.Http;

namespace Blog.Application.ViewModels
{
    public class ThumbnailViewModel
    {
        public ThumbnailViewModel(string url, string publicId)
        {
            Url = url;
            PublicId = publicId;
        }

        public string Url { get; set; }
        public string PublicId { get; set; }
    }

    public class ThumbnailRequestViewModel
    {     

        public IFormFile File { get; set; }

      
    }
}
