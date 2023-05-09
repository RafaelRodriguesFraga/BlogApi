using Blog.Domain.Repositories;
using Blog.Domain.Repositories.Base;
using Blog.Infra.Repositories;
using Blog.Infra.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infra.CrossCutting.IoC
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseWriteRepository<>), typeof(BaseWriteRepository<>));
            services.AddScoped(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>));

            services.AddScoped<IPostWriteRepository, PostWriteRepository>();

            return services;
        }
    }
}
