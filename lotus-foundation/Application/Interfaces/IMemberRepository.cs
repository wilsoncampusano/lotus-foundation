using Domain.Entities;
using Domain.Members;

namespace Application.Interfaces
{
    public interface IMemberRepository
    {
        Task AddAsync(Member member, CancellationToken ct);
        Task<Member?> GetByIdAsync(MemberId id, CancellationToken ct);
        Task<bool> ExistsAsync(MemberId id, CancellationToken ct);


    }

}
