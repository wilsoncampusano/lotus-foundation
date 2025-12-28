using Domain.Members;

namespace Application.Members.CreateMember
{
    public record CreateMemberCommand(
      string FirstName,
      string LastName,
      Division Division,
      MemberRole Role,
      string Territorio,
      string SubDireccion,
      string? Zona,
      string? Provincia
  );

}
