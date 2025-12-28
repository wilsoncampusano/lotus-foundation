using Domain.Members;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories
{
    public interface IMemberRepository
    {
        Task AddAsync(Member member);
    }


    public class MemberRepository : IMemberRepository
    {
        private readonly IMongoCollection<Member> _collection;

        public MemberRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Member>("members");
        }

        public async Task AddAsync(Member member)
        {
            await _collection.InsertOneAsync(member);
        }
    }

}
