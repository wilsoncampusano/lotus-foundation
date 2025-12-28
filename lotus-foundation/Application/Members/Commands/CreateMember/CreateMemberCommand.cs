using Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Members.Commands.CreateMember
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
