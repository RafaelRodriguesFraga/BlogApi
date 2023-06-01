using Blog.Domain.Entities;
using Blog.Domain.Repositories.Base;

namespace Blog.Domain.Repositories
{
    public interface IPostReadRepository : IBaseReadRepository<Post>
    {
    }
}
