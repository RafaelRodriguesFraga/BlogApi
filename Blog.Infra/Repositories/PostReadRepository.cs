using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Infra.DbSettings;
using Blog.Infra.Repositories.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace Blog.Infra.Repositories
{
    public class PostReadRepository : BaseReadRepository<Post>, IPostReadRepository
    {
        public PostReadRepository(IMongoSettings settings) : base(settings)
        {
        }

        public async Task<IEnumerable<Post>> SearchByTitleAsync(string title)
        {
            var filter = Builders<Post>.Filter.Regex("Title", new BsonRegularExpression(title, "i"));

            var result = await _collection.Find(filter).ToListAsync();

            return result;
        }
    }
}

