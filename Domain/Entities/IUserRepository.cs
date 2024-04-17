using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.SeedWork;

namespace UserProfileService.Domain.Entities
{
    public interface IUserRepository
    {
        IUnitOfWork UnitOfWork { get; }

        User Add(User user);

        void Update(User user);

        Task<User> GetAsync(int userId);
    }
}
