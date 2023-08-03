using Domain.Dtos.Admin;

namespace Services.Admin
{
    public interface IUserService
    {
        Task RegisterUser(AdminSignUpDTO signUpDTO);
    }
}
