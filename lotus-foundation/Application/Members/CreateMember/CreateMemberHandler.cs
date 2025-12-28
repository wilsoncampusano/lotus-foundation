using Application.Interfaces;
using Domain.Entities;
using Domain.Members;

namespace Application.Members.CreateMember
{
    public class CreateMemberHandler
    {
        private readonly IMemberRepository _repository;

        public CreateMemberHandler(IMemberRepository repository)
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

            await _repository.Save(member);
        }
    }

}
