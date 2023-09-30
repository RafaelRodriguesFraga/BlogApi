using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using DotnetBoilerplate.Components.Infra.MongoDb.DbSettings;
using DotnetBoilerplate.Components.Infra.MongoDb.Repositories.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

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

        public async Task<(IEnumerable<Post> result, int totalRecords)> FindAllPaginatedAsync(int page, int quantityPerPage)
        {
            var skip = page == 1 ? 0 : (page - 1) * quantityPerPage;

            var filter = Builders<Post>.Filter.Empty;

            var collection = _collection
                 .Find(filter);

            var totalRecords = (int)collection.Count();

            var result = await collection
                .Skip(skip)
                .Limit(quantityPerPage)
                .SortByDescending(p => p.CreatedAt)
                .ToListAsync();

            return (result, totalRecords);

        }

        public async Task<(IEnumerable<Post> result, int totalRecords)> FindAllPaginatedAsync(
            int page,
            int quantityPerPage, 
            Expression<Func<Post, bool>> filterExpression)
        {
            var skip = page == 1 ? 0 : (page - 1) * quantityPerPage;

            var collection = _collection.Find(filterExpression);

            var totalRecords = (int)collection.Count();

            var result = await collection
                     .Skip(skip)
                     .Limit(quantityPerPage)
                     .SortByDescending(p => p.CreatedAt)
                     .ToListAsync();

            return (result, totalRecords);
        }

        public async Task<IEnumerable<Post>> GetRelatedPostsAsync(Guid id, string tag)
        {

            var collection = await _collection
                 .Find(p => p.Tag == tag && p.Id != id)
                 .SortByDescending(p => p.CreatedAt)
                 .Limit(5)
                 .ToListAsync();

            return collection;
        }
    }
}

