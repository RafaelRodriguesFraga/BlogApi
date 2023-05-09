using Microsoft.Extensions.DependencyInjection;
using Blog.Application.Services;
using Blog.Application.Services.Base;

namespace Blog.Infra.CrossCutting.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseServiceApplication, BaseServiceApplication>();

            services.AddScoped<IPostServiceApplication, PostServiceApplication>();

            return services;
        }
    }
}

