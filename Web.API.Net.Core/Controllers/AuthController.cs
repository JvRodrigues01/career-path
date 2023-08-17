using Api.Controllers.Abstract;
using Domain.Dtos;
using Domain.Dtos.Admin;
using Microsoft.AspNetCore.Mvc;
using Services.Admin;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/admin/login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponse<SingleResponse<AdminAuthDTO>>))]
        public async Task<IActionResult> Login([FromBody] AdminLoginDTO loginDto)
        {
            if (!ModelState.IsValid)
                return ApiBadRequest(ModelState);

            return ApiOk(await _userService.HandleAdminLogin(loginDto));
        }

        [HttpPost("/admin/register")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponse<SingleResponse<EmptyResult>>))]
        public async Task<IActionResult> RegisterUser([FromBody] AdminSignUpDTO signUpDTO)
        {
            if (!ModelState.IsValid)
                return ApiBadRequest(ModelState);

            await _userService.RegisterUser(signUpDTO);
            return ApiOk();
        }
    }
}
