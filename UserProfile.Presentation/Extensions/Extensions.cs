using Microsoft.EntityFrameworkCore;
using UserProfileService.Domain.Entities;
using UserProfileService.Infrastructure;
using UserProfileService.Infrastructure.Repositories;

namespace UserProfile.Presentation.Extensions
{
    internal static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            var services=builder.Services;




            services.AddDbContext<UserProfileContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("userprofiledb"));
            });

            services.AddScoped<IUserRepository,UserRepository>();
        }
    }
}
