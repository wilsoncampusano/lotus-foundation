using Domain.Common;
using Domain.Entities;

namespace Domain.Members.Events
{
    public sealed class MemberCreatedDomainEvent : IDomainEvent
    {
        public MemberId MemberId { get; }
        public DateTime OccuredOn { get; } = DateTime.UtcNow;
        public MemberCreatedDomainEvent(MemberId memberId)
        {
            MemberId = memberId;
        }
    }
}
