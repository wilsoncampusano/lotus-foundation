using Domain.Members;
using Infraestructure.Persistence.Mongo.Serializers;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Mongo
{
    public static class MongoMappings
    {
        public static void Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Member)))
            {
                BsonClassMap.RegisterClassMap<Member>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(x => x.Id);
                });
            }

            BsonSerializer.RegisterSerializer(new MemberSerializer());
        }
    }
}
