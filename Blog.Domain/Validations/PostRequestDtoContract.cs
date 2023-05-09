using Blog.Domain.Dtos;
using Blog.Domain.Validation;
using FluentValidation;

namespace Blog.Domain.Validations
{
    public class PostRequestDtoContract : AbstractValidator<PostRequestDto>
    {

        public PostRequestDtoContract()
        {
            RuleFor(dto => dto.Title)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");
        }
    }
}
