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

        public async Task<MemberId> Handle(CreateMemberCommand command, CancellationToken ct)
        {
            var memberId = MemberId.New();

            if(await _repository.ExistsAsync(memberId, ct))
                throw new InvalidOperationException("Member with the same ID already exists.");
            
            var member = new Member(
                memberId,
                new FullName(command.FirstName, command.LastName),
                command.Division,
                command.Role,
                new OrganizationUnit(
                    command.Territorio,
                    command.SubDireccion,
                    command.Zona,
                    command.Provincia
                )
            );

            await _repository.AddAsync(member, ct);
            return memberId;
        }
    }

}
