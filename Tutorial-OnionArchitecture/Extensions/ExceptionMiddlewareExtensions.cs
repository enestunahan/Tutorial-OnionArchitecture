using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Tutorial_OnionArchitecture.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app , ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {

                appError.Run(async context =>
                {
                    context.Response.ContentType= "application/json";

                    var contextFeauture = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeauture != null)
                    {
                        logger.LogError("There is a problem : " + contextFeauture);


                        context.Response.StatusCode = contextFeauture.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeauture.Error.Message
                        }.ToString());

                    }
                });

            });
        }

    }
}
