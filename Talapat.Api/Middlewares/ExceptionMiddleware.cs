using System.Net;
using System.Text.Json;
using Talapat.Api.Errors;

namespace Talapat.Api.Middlewares
{
    public class ExceptionMiddleware

    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next , ILogger<ExceptionMiddleware> logger , IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync (HttpContext httpcontext)
        {
            try
            {
                await _next.Invoke(httpcontext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                httpcontext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpcontext.Response.ContentType = "application/json";

                var response = _env.IsDevelopment() ?
                    new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    :
                    new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);
               
                var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                
                var json = JsonSerializer.Serialize(response);

                await httpcontext.Response.WriteAsync(json); 
            }
        }
    }
}
