
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace Dkd.Shared.WebApi.AutoWrapper.Models
{
    public class ApiProblemDetailsExceptionResponse: ProblemDetails
    {
        public bool IsError { get; set; }
        public ErrorDetails Errors { get; set; }
        public class ErrorDetails
        {
            public string Message { get; set; }
            public string Type { get; set; }
            public string Source { get; set; }
            public string Raw { get; set; }
        }
    }


}
