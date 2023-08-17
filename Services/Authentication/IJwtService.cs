using Domain.Entities.Admin;

namespace Services.Authentication
{
    public interface IJwtService
    {
        string GenerateAdmin(User user);
    }
}
