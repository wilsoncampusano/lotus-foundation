using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMemberRepository
    {
        Task Save(Member member);
    }

}
