using Blog.Domain.Entities;
using DotnetBoilerplate.Components.Domain.MongoDb.Repositories.Base;

namespace Blog.Domain.Repositories
{
    public interface IPostWriteRepository : IBaseWriteRepository<Post>
    {
    }
}
