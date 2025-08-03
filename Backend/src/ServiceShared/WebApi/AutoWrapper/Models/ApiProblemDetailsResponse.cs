using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace Dkd.Shared.WebApi.AutoWrapper.Models
{
    public class ApiProblemDetailsResponse: ProblemDetails
    {
        public bool IsError { get; set; }
    }
}
