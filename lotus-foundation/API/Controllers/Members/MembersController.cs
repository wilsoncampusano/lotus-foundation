using Application.Members.Commands.CreateMember;
using Application.Members.Handlers.CreateMember;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;


namespace API.Controllers.Members
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private CreateMemberHandler _handler;

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberCommand command)
        {
            await _handler.Handle(command);
            return Ok();
        }

    }
}
