using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Dtos;

namespace UserProfileService.Application.Queries
{
    public interface IUserProfileQueries
    {
        Task<UserProfileDto> GetUserProfile(int userId);
        Task<LoginResponseDto> GetUser_Login(string email,string password);
    }
}
