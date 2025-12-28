using Domain.Members;

namespace Application.Interfaces
{
    public interface IMemberRepository
    {
        Task Save(Member member);
    }

}
