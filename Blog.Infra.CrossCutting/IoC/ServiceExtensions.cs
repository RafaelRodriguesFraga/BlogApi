using Microsoft.Extensions.DependencyInjection;
using Blog.Application.Services;

namespace Blog.Infra.CrossCutting.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPostServiceApplication, PostServiceApplication>();

            return services;
        }
    }
}

