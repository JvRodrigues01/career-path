using Domain.Dtos.Admin;
using Domain.Entities.User;

namespace Services.Admin
{
    public interface IUserService
    {
        Task RegisterUser(AdminSignUpDTO signUpDTO);
        Task<AdminAuthDTO> HandleAdminLogin(AdminLoginDTO loginDTO);
        Task DisableAbsentUsers();
    }
}
