using Domain.Entities.User;

namespace Infra.Repository.Admin
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User user);
        Task<User> GetUserByUsername(string userName);
    }
}
