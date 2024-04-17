using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Dtos;
using UserProfileService.Domain.Entities;
using UserProfileService.Infrastructure;

namespace UserProfileService.Application.Queries
{
    public class UserProfileQueries : IUserProfileQueries
    {
        private readonly IUserRepository _userRepository;
        private readonly UserProfileContext _db;
        public UserProfileQueries(IUserRepository userRepository, UserProfileContext userProfileContext)
        {
            _userRepository = userRepository;   
            _db = userProfileContext;   
        }
        public async Task<UserProfileDto> GetUserProfile(int userId)
        {
            var user=await _db.users.FindAsync(userId);
            if (user == null)
                throw new KeyNotFoundException();

            return new UserProfileDto(user.Id, user.UserName, user.Email);
          
        }

        public async Task<LoginResponseDto> GetUser_Login(string email, string password)
        {
            var user=await _db.users.FirstOrDefaultAsync(x=>x.Email==email);

            if (user == null)
            {
                throw new Exception("User does not exiset");
            }
            if (user.Password!=password)
            {
                throw new Exception("Password incurect");

            }
            return new LoginResponseDto()
            {
                Email = email,
                UserId = user.Id,
                UserName = user.UserName,
            };
            
        }
    }
}
