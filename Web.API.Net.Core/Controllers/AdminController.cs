using Api.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;
using Services.Admin;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseApiController
    {
        public AdminController(IUserService userService)
        {
        }
    }
}
