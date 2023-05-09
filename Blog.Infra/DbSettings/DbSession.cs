using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blog.Infra.DbSettings
{
    public class DbSession
    {

        private readonly MongoClient _client;
        public IMongoDatabase Database { get; private set; }   
        public IConfiguration Configuration { get; private set; }          
    }
}
