using IdentityService.Application.Dtos;
using IdentityService.Application.Service;
using IdentiyService.Messaging.Http;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Command.UserRegister
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, RegisterResponseDto>
    {
        private readonly IMessagingHttpService _http;

        private ITokenService tokenService;
        public UserRegisterCommandHandler(ITokenService tokenService, IMessagingHttpService messagingHttpService)
        {
            this.tokenService = tokenService;  
            _http = messagingHttpService;
        }
        public async Task<RegisterResponseDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {

            var userid = await _http.CreateUserAsync(request);
            var Token = tokenService.GenerateToken(userid, request.UserName, request.Email);

            return new RegisterResponseDto()
            {
                IsSuccess = true,
                Message = "Success",
                Token = Token
            };

        }
    }
}
