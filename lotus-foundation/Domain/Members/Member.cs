using Domain.Entities;

namespace Domain.Members
{
   public class Member
{
    public MemberId Id { get; private set; }
    public FullName Name { get; private set; }
    public Division Division { get; private set; }
    public MemberRole Role { get; private set; }
    public OrganizationalAssignment Assignment { get; private set; }
    public MemberStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Member() { }

    public Member(
        MemberId id,
        FullName name,
        Division division,
        MemberRole role,
        OrganizationalAssignment assignment)
    {
        Id = id;
        Name = name;
        Division = division;
        Role = role;
        Assignment = assignment;
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
}

}
