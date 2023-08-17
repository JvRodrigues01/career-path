using Domain.Dtos.Admin;

namespace Services.Admin
{
    public interface IUserService
    {
        Task RegisterUser(AdminSignUpDTO signUpDTO);
        Task<AdminAuthDTO> HandleAdminLogin(AdminLoginDTO loginDTO);
        Task DisableAbsentUsers();
    }
}
