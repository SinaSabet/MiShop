using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Commands.CreateUser;
using UserProfileService.Application.Dtos;
using UserProfileService.Application.Queries;

namespace UserProfileService.Application.Extensions
{
    public static class Extentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            //Services
            services.AddScoped<IUserProfileQueries, UserProfileQueries>();


            //Mediatr
            services.AddTransient<IRequestHandler<CreateUserCommand, ResponseDto<int>>, CreateUserCommandHandler>();
            return services;
        }
    }
}
