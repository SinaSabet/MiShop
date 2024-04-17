using IdentityService.Application.Command.UserRegister;
using IdentityService.Application.Dtos;
using IdentityService.Application.Service;
using IdentiyService.Messaging.Http;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices( this IServiceCollection services)
        {
            services.AddHttpClient();

            //Services
            services.AddScoped<IMessagingHttpService, MessagingHttpService>();
            services.AddScoped<ITokenService,TokenService>();

            //Mediatr
            services.AddTransient<IRequestHandler<UserRegisterCommand, RegisterResponseDto>, UserRegisterCommandHandler>();
            return services;
        }

    }
}
