using Blog.Domain.Repositories;
using Blog.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infra.CrossCutting.IoC
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPostWriteRepository, PostWriteRepository>();
            services.AddScoped<IPostReadRepository, PostReadRepository>();

            return services;
        }
    }
}
