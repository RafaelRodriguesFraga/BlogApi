using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using DotnetBoilerplate.Components.Infra.MongoDb.DbSettings;
using DotnetBoilerplate.Components.Infra.MongoDb.Repositories.Base;

namespace Blog.Infra.Repositories
{
    public class PostWriteRepository : BaseWriteRepository<Post>, IPostWriteRepository
    {
        public PostWriteRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
