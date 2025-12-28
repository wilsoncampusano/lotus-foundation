using Application.Interfaces;
using Domain.Members;
using Infraestructure.Persistence.Mongo;
using MongoDB.Driver;

namespace Infraestructure.Persistence.Repositories
{


    public class MongoMemberRepository : IMemberRepository
    {
        private readonly IMongoCollection<Member> _collection;

        public MongoMemberRepository(MongoContext context)
        {
            _collection = context.Database.GetCollection<Member>("members");
        }
        public async Task Save(Member member)
            => await _collection.InsertOneAsync(member);
    }


}
