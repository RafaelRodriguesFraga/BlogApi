using Pe2Api.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Blog.Domain.Repositories.Base
{
    public interface IBaseReadRepository<TEntity> where TEntity : class, IBaseEntity
    {
        IQueryable<TEntity> AsQueryable();    
        TEntity FindOne(Expression<Func<TEntity, bool>> filterExpression);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression);

        TEntity FindById(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);
        IEnumerable<TEntity> FindAll();
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<(IEnumerable<TEntity> result, int totalRecords)> FindAllPaginatedAsync(int page, int quantityPerPage);
        Task<(IEnumerable<TEntity> result, int totalRecords)> FindAllPaginatedAsync(int page, int quantityPerPage, Expression<Func<TEntity, bool>> filterExpression);
    }
}