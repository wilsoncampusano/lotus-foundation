using Application.Interfaces;
using Domain.Entities;
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

        public async Task AddAsync(Member member, CancellationToken ct)
             => await _collection.InsertOneAsync(member, ct);

        public Task<bool> ExistsAsync(MemberId id, CancellationToken ct)
        {
           var filter = Builders<Member>.Filter.Eq("_id", id.Value);
            return _collection
                .Find(filter)
                .AnyAsync(ct);
        }

        public async Task<Member?> GetByIdAsync(MemberId id, CancellationToken ct)
        {
            var filter = Builders<Member>.Filter.Eq("_id", id.Value);

            return await _collection
                .Find(filter)
                .FirstOrDefaultAsync(ct);
        }

        public async Task Save(Member member)
            => await _collection.InsertOneAsync(member);
    }


}
