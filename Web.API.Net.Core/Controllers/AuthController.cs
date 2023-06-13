using Api.Controllers.Abstract;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        [HttpPost("/admin/login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ServiceResponse<SingleResponse<EmptyResult>>))]
        public async Task<IActionResult> Login()
        {
            if (!ModelState.IsValid)
                return ApiBadRequest(ModelState);

            return ApiOk();
        }
    }
}
