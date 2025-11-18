namespace Talapat.Api.Errors
{
    public class ApiExceptionResponse : ApiResponse
    {
        public string? Details { get; set; }
        public ApiExceptionResponse(int statuseCode , string? message = null , string? details = null) 
            :base(statuseCode , message)
        {
            Details = details;
        }
    }
}
