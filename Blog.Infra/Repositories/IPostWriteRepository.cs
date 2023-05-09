using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Infra.DbSettings;
using Blog.Infra.Repositories.Base;

namespace Blog.Infra.Repositories
{
    public class PostWriteRepository : BaseWriteRepository<Post>, IPostWriteRepository
    {
        public PostWriteRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
