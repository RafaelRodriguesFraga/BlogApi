using Blog.Domain.Entities;
using DotnetBoilerplate.Components.Domain.MongoDb.Repositories.Base;
using System.Linq.Expressions;

namespace Blog.Domain.Repositories
{
    public interface IPostReadRepository : IBaseReadRepository<Post>
    {
        Task<(IEnumerable<Post> result, int totalRecords)> FindAllPaginatedAsync(int page, int quantityPerPage);
        Task<(IEnumerable<Post> result, int totalRecords)> FindAllPaginatedAsync(int currentPage, int quantityPerPage, Expression<Func<Post, bool>> filterExpression);
        Task<IEnumerable<Post>> SearchByTitleAsync(string title);
        Task<IEnumerable<Post>> GetRelatedPostsAsync(Guid id, string tag);
    }
}
