using Application.Members.CreateMember;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Members
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private CreateMemberHandler _handler;
        public MembersController(CreateMemberHandler handler)
        {
            _handler = handler;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberCommand command)
        {
            await _handler.Handle(command);
            return Ok();
        }

    }
}
