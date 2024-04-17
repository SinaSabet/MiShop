using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities;
using UserProfileService.Domain.SeedWork;

namespace UserProfileService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserProfileContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(UserProfileContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public User Add(User user)
        {
            return _context.users.Add(user).Entity;
        }

        public async Task<User> GetAsync(int userId)
        {
            var order = await _context.users.FindAsync(userId);
            return order;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
