using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Infra.DbSettings;
using Blog.Infra.Repositories.Base;

namespace Blog.Infra.Repositories
{
    public class PostReadRepository : BaseReadRepository<Post>, IPostReadRepository
    {
        public PostReadRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}

