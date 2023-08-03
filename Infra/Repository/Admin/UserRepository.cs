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
    }
}
