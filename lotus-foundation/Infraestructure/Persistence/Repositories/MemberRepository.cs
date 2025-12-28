using Application.Interfaces;
using Domain.Entities;

namespace Infraestructure.Persistence.Repositories
{


    public class MongoMemberRepository : IMemberRepository
    {
        public Task Save(Member member)
        {
            throw new NotImplementedException();
        }
    }


}
