using Application.Members.Commands.CreateMember;
using Domain.Members;
using Infraestructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Members.Handlers.CreateMember
{
    public class CreateMemberHandler
    {
        private readonly MemberRepository _repository;

        public CreateMemberHandler(MemberRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateMemberCommand command)
        {
            var member = new Member(
                MemberId.New(),
                new FullName(command.FirstName, command.LastName),
                command.Division,
                command.Role,
                new OrganizationalAssignment(
                    command.Territorio,
                    command.SubDireccion,
                    command.Zona,
                    command.Provincia
                )
            );

            await _repository.AddAsync(member);
        }
    }

}
