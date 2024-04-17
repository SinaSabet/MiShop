using IdentityService.Application.Command.UserRegister;
using IdentityService.Application.Dtos;
using IdentityService.Application.Service;
using Identiy.Service.Protos;
using Identiy.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProfileService.Application.Commands.CreateUser;

namespace Identiy.Service.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
      
        private readonly IMediator _mediator;
        private readonly LoginGrpcService _loginGrpcService;
        private readonly ITokenService _tokenService;
        public IdentityController( IMediator mediator, ITokenService tokenService)
        {
           
            _mediator = mediator;
            _loginGrpcService = new LoginGrpcService();
            _tokenService = tokenService;   
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<RegisterResponseDto>> Register([FromBody] UserRegisterCommand userRegisterCommand)
        {
        
            var result=await _mediator.Send(userRegisterCommand); 

            return Ok(result);  

        }


        [HttpPost("[action]")]
        public async Task<ActionResult<RegisterResponseDto>> Login([FromBody] GetUserRequest getUserRequest)
        {
            var userInfo = await _loginGrpcService.GetUser(getUserRequest);
            var Token = _tokenService.GenerateToken(userInfo.Userid,userInfo.Username,userInfo.Email);
            //var result = await _mediator.Send(userRegisterCommand);
            RegisterResponseDto registerResponseDto = new RegisterResponseDto()
            {
                IsSuccess = true,
                Message = "Success",
                Token = Token
            
            
            };
            return Ok(registerResponseDto);

        }


    }
}
