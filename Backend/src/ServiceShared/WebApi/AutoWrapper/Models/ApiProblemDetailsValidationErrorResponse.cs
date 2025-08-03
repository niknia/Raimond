using Dkd.Shared.WebApi.AutoWrapper.Wrappers;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace Dkd.Shared.WebApi.AutoWrapper.Models
{
    public class ApiProblemDetailsValidationErrorResponse: ProblemDetails
    {
        public bool IsError { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}
