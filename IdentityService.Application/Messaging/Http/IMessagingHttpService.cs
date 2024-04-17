using IdentityService.Application.Command.UserRegister;
using IdentityService.Application.Dtos;

namespace IdentiyService.Messaging.Http
{
    public interface IMessagingHttpService
    {
        Task<int> CreateUserAsync(UserRegisterCommand data);
    }
}
