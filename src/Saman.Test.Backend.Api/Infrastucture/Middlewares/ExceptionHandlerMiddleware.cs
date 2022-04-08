using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Saman.Test.Backend.Domain.Common;
using Saman.Test.Backend.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Api.Infrastucture.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            try
            {
                await _next.Invoke(context);
            }
            catch (SamanValidationException exception)
            {
                context.Response.StatusCode = (int)exception.HttpStatusCode;
                context.Response.ContentType = "application/json";

                var response = new Envelop()
                {
                    Error = new EnvelopError()
                    {
                        Exception = exception.InnerException,
                        ErrorCode = exception.ErrorCode,
                        CustomMessage = exception.CustomMessage
                    },
                    ValidationErrors = exception.ValidationErrors
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, jsonSerializerSettings));
            }
            catch (SamanException exception)
            {
                context.Response.StatusCode = (int)exception.HttpStatusCode;
                context.Response.ContentType = "application/json";

                var response = new Envelop()
                {
                    Error = new EnvelopError()
                    {
                        Exception = exception.InnerException,
                        ErrorCode = exception.ErrorCode,
                        CustomMessage = exception.CustomMessage
                    },
                    Data = exception.Value
                };


                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, jsonSerializerSettings));
            }
            catch (Exception exception)
            {
                var logBody = $@"url : {context.Request.Path}";

                _logger.LogCritical(exception, logBody);

                exception.Data.Add("HttpRequest", logBody);

                if (context.Response.HasStarted)
                    throw;

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var response = new Envelop()
                {
                    Error = new EnvelopError()
                    {
                        ErrorCode = ErrorCode.UnknownServerError,
                    },
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, jsonSerializerSettings));
            }
        }
    }
}
