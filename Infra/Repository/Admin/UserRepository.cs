using Domain.Entities.User;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Admin
{
    public class UserRepository : IUserRepository
    {
        public readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserByUsername(string userName)
        {
            return await _context.Users.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Username == userName);
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> UpdateRange(List<User> users)
        {
            _context.Users.UpdateRange(users);
            await _context.SaveChangesAsync();

            return users;
        }

        public async Task<List<User>> GetAbsentUsers()
        {
            return await _context.Users
                .Where(x => x.LastLogin.HasValue && x.LastLogin.Value <= DateTime.Today.AddDays(-7))
                .ToListAsync();
        }
    }
}
