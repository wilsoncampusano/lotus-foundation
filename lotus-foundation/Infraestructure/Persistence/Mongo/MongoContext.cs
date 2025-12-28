using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infraestructure.Persistence.Mongo
{
    public class MongoContext
    {
        public IMongoDatabase Database { get; }

        public MongoContext(IOptions<MongoSettings> options)
        {
            var settings = options.Value;

            var client = new MongoClient(settings.ConnectionString);
            Database = client.GetDatabase(settings.Database);
        }
    }

}
