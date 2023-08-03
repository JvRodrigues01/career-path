using Api.Controllers.Abstract;
using Domain.Dtos;
using Domain.Dtos.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseApiController
    {
        [HttpPost("/admin/register")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponse<SingleResponse<EmptyResult>>))]
        public async Task<IActionResult> RegisterUser(AdminSignUpDTO signUpDTO)
        {
            if (!ModelState.IsValid)
                return ApiBadRequest(ModelState);

            return ApiOk();
        }
    }
}
