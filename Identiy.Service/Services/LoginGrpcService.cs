using Grpc.Core;
using Grpc.Net.Client;
using Identiy.Service.Protos;

namespace Identiy.Service.Services
{
    public class LoginGrpcService
    {
        public async Task<UserResponse> GetUser(GetUserRequest request)
        {
            try
            {
                using var channel = GrpcChannel.ForAddress("http://localhost:5297");
                var client = new Login.LoginClient(channel);

                var res = await client.GetUserAsync(request);

                UserResponse userResponse = new UserResponse();
                userResponse = res;
                return res;
            }
            catch (Exception e)
            {
                throw new Exception($"Grpc Error ,  Error Message {e.Message}");
            }
          
        }
    }
}
