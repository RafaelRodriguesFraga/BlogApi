using System.Linq.Expressions;
using Blog.Application.Pagination;
using Blog.Domain.Repositories.Base;
using Blog.Infra.DbSettings;
using MongoDB.Driver;
using Pe2Api.Domain.Entities.Base;

namespace Blog.Infra.Repositories.Base
{
    public class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly IMongoCollection<TEntity> _collection;
        public BaseReadRepository(IMongoSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public TEntity FindById(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);

            return _collection.Find(filter).SingleOrDefault();

        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);

            return await _collection.Find(filter).SingleOrDefaultAsync();

        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await _collection.Find(filterExpression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            var filter = Builders<TEntity>.Filter.Empty;

            return await _collection.Find(filter).ToListAsync();


        }
        public async Task<(IEnumerable<TEntity> result, int totalRecords)> FindAllPaginatedAsync(int page, int quantityPerPage)
        {
            var skip = page == 1 ? 0 : (page - 1) * quantityPerPage;

            var filter = Builders<TEntity>.Filter.Empty;

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

        public async Task<(IEnumerable<TEntity> result, int totalRecords)> FindAllPaginatedAsync(int page, int quantityPerPage, Expression<Func<TEntity, bool>> filterExpression)
        {
            var skip = page == 1 ? 0 : (page - 1) * quantityPerPage;

            var collection = _collection
                 .Find(filterExpression);

            var totalRecords = (int)collection.Count();

            var result = await collection
                .Skip(skip)
                .Limit(quantityPerPage)
                .SortByDescending(p => p.CreatedAt)
                .ToListAsync();

            return (result, totalRecords);

        }
        public IEnumerable<TEntity> FindAll()

        {
            var filter = Builders<TEntity>.Filter.Empty;

            return _collection.Find(filter).ToList();
        }
    }
}