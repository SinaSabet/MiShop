using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities;
using UserProfileService.Infrastructure.Repositories;

namespace UserProfileService.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<UserProfileContext, UserProfileContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}
