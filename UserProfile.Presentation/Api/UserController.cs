using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProfileService.Application.Commands.CreateUser;
using UserProfileService.Application.Dtos;

namespace UserProfile.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseDto<int>>> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            var result=await _mediator.Send(createUserCommand);   

            return Ok(result);
        }
    }
}
