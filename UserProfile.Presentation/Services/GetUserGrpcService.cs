using Grpc.Core;
using UserProfile.Presentation.Protos;
using UserProfileService.Application.Queries;

namespace UserProfile.Presentation.Services
{
    public class GetUserGrpcService:Login.LoginBase
    {
        private readonly IUserProfileQueries _userProfileQueries;
        public GetUserGrpcService(IUserProfileQueries userProfileQueries)
        {
            _userProfileQueries = userProfileQueries;
        }
        public override async Task<UserResponse> GetUser(GetUserRequest request, ServerCallContext context)
        {

            var user = await _userProfileQueries.GetUser_Login(request.Email, request.Password);

            return new UserResponse()
            {
                Email = user.Email,
                Userid = user.UserId,
                Username = user.UserName,

            };
        }
    }
}
