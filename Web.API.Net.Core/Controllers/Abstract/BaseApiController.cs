using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers.Abstract
{
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult ApiBadRequest(ModelStateDictionary modelState)
        {
            var errors = new List<string>();
            foreach (var keyModelStatePair in modelState)
            {
                errors.AddRange(keyModelStatePair.Value.Errors.Select(e => e.ErrorMessage));
            }
            var response = new ServiceResponse<BaseResponse>(false, errors);

            return BadRequest(response);
        }

        protected IActionResult ApiOk<T>(T data)
        {
            var response = new ServiceResponse<SingleResponse<T>>(true, new SingleResponse<T>(data));

            return Ok(response);
        }

        protected IActionResult ApiOk<T>(PagedResponse<T> data)
        {
            var response = new ServiceResponse<PagedResponse<T>>(true, data);

            return Ok(response);
        }

        protected IActionResult ApiOk()
        {
            var response = new ServiceResponse<BaseResponse>(true);

            return Ok(response);
        }
    }
}
