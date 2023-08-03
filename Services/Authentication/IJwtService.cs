using Domain.Entities.User;

namespace Services.Authentication
{
    public interface IJwtService
    {
        string GenerateAdmin(User user);
    }
}
