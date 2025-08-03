using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using static Dkd.Shared.WebApi.AutoWrapper.Wrappers.ApiProblemDetailsMember;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace Dkd.Shared.WebApi.AutoWrapper.Wrappers
{

    internal class ApiProblemDetails: ProblemDetails
    {
        public ApiProblemDetails(int statusCode)
        {
            IsError = true;
            Status = statusCode;
            Type = $"https://httpstatuses.com/{statusCode}";
            Title = ReasonPhrases.GetReasonPhrase(statusCode);
        }

        public ApiProblemDetails(ProblemDetails details)
        {
            IsError = true;
            Details = details;
        }

        [JsonProperty(Order = -2)]
        public bool IsError { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Order = 1)]
        public ErrorDetails Errors { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Order = 1)]
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
        [JsonIgnore]
        public ProblemDetails Details { get; set; }
    }
}
