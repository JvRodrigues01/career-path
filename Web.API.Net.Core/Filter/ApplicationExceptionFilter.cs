using Domain.Dtos;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Filter
{
    public class ApplicationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException)
            {
                var exception = context.Exception as BadRequestException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new ObjectResult(new ServiceResponse<object>(false, new List<string>
                {
                    exception.Message
                }));
            }
            else if (context.Exception is NonAuthoritativeException)
            {
                var exception = context.Exception as NonAuthoritativeException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NonAuthoritativeInformation;
                context.Result = new ObjectResult(new ServiceResponse<object>(false, new List<string>
                {
                    exception.Message
                }));
            }

            else
                UnknownError(context);
        }

        private static void UnknownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ServiceResponse<object>(false, new List<string>
            {
                ErrorMessages.Unknown_Error,
            }));
        }
    }
}
