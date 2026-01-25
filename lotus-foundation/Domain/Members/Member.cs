using Domain.Common;
using Domain.Entities;
using Domain.Members.Events;

namespace Domain.Members
{
    public class Member : AggregateRoot
    {
        public MemberId Id { get; private set; }
        public FullName Name { get; private set; }
        public Division Division { get; private set; }
        public MemberRole Role { get; private set; }
        public OrganizationUnit Organization { get; private set; }
        public MemberStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Member() { }

        public Member(
                MemberId id,
                FullName name,
                Division division,
                MemberRole role,
                OrganizationUnit organization)
        {
            Id = id;
            Name = name;
            Division = division;
            Role = role;
            Organization = organization;
            Status = MemberStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        public void ChangeRole(MemberRole newRole)
        {
            Role = newRole;
        }

        public void Deactivate()
        {
            Status = MemberStatus.Inactive;
        }


        public void AssignRole(MemberRole role)
        {
            Role = role;

        }

       public static Member Create(
            MemberId id,
            FullName name,
            Division division,
            MemberRole role,
            OrganizationUnit organization)
        {
            var member =  new Member(
                id,
                name,
                division,
                role,
                organization
            );
            member.AddDomainEvent(new MemberCreatedDomainEvent(member.Id));

            return member;
        }
    }

}
