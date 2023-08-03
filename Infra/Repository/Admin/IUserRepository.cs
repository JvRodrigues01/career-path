using Domain.Entities.User;

namespace Infra.Repository.Admin
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User user);
        Task<User> GetUserByUsername(string userName);
        Task<User> Update(User user);
        Task<List<User>> UpdateRange(List<User> users);
        Task<List<User>> GetAbsentUsers();
    }
}
