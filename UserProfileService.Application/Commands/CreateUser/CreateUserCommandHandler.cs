using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Dtos;
using UserProfileService.Domain.Entities;
using UserProfileService.Domain.Enums;
using UserProfileService.Domain.ValueObjects;

namespace UserProfileService.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseDto<int>>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }
        public async Task<ResponseDto<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Street,request.City,request.State,request.Country,request.ZipCode);
            var user=new User(request.FirstName,request.LastName,request.Email,request.UserName,request.Password
                ,address,Gender.Male);

            _userRepository.Add(user);

            var res=await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            if (res)
                return new ResponseDto<int>()
                {
                    Data = user.Id,
                    IsSuccess = true,
                    Message = "Success"
                };


            throw new Exception("Add user error");
        }
    }
}
