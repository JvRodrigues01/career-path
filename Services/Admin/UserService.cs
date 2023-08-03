using Domain.Dtos.Admin;
using Domain.Entities.User;
using Domain.Exceptions;
using Infra.Repository.Admin;
using SecureIdentity.Password;
using Services.Authentication;

namespace Services.Admin
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task RegisterUser(AdminSignUpDTO signUpDTO)
        {
            var user = new User()
            {
                Name = signUpDTO.Name,
                Username = signUpDTO.UserName,
                HashedPassword = PasswordHasher.Hash(signUpDTO.Password)
            };

            await _userRepository.RegisterUser(user);
        }

        public async Task<AdminAuthDTO> HandleAdminLogin(AdminLoginDTO loginDTO)
        {
            var user = await _userRepository.GetUserByUsername(loginDTO.UserName);

            if (user == null)
                throw new Exception("User not found");

            if(!PasswordHasher.Verify(user.HashedPassword, loginDTO.Password))
                throw new Exception(ErrorMessages.Unable_Login);

            var token = _jwtService.GenerateAdmin(user);

            return new AdminAuthDTO
            {
                Token = token,
            };
        }
    }
}
