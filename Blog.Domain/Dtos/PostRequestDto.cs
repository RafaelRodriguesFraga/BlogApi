using Blog.Domain.Dtos.Base;
using Blog.Domain.Entities;
using Blog.Domain.Validations;
using Microsoft.AspNetCore.Http;

namespace Blog.Domain.Dtos
{
    public class PostRequestDto : BaseDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Meta { get; set; }
        public string[]? Tags { get; set; }
        public string Thumbnail { get; set; }

        public override void Validate()
        {
            var validation = new PostRequestDtoContract();
            var validationResult = validation.Validate(this);

            AddNotifications(validationResult);
        }
    }

    
}
