using Blog.Infra.DbSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;


namespace Blog.Infra.CrossCutting.IoC
{
    public static class MongoDbExtensions
    {    

        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
            services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));
            services.AddSingleton<IMongoSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value);
            return services;
        }
    }
}
