using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Mongo
{

    public class MongoHealthCheck
    {
        private readonly MongoContext _context;

        public MongoHealthCheck(MongoContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckAsync()
        {
            var result = await _context.Database
                .RunCommandAsync((Command<BsonDocument>)"{ ping: 1 }");

            return result.Contains("ok");
        }
    }

}
