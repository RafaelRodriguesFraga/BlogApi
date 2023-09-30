using AutoMapper;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;

namespace Blog.Application.Mappers
{
    public class EntityToViewModelMapper : Profile
    {
        public EntityToViewModelMapper()
        {
            CreateMap<IEnumerable<Post>, IEnumerable<PostResponseViewModel>>();
            CreateMap<IEnumerable<Post>, IEnumerable<RelatedPostViewModel>>();
              
        }

    }
}
