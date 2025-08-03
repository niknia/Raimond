using FluentValidation;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace Dkd.Shared.WebApi.Registrar;

public abstract partial class AbstractWebApiDependencyRegistrar
{
    /// <summary>
    /// Register Controllers
    /// Configure System.Text.Json
    /// Register FluentValidation
    /// Configure ApiBehaviorOptions
    /// </summary>
    protected virtual void AddControllers()
    {
        Services
            .AddControllers(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                options.JsonSerializerOptions.Converters.Add(new DateTimeNullableConverter());
                options.JsonSerializerOptions.Encoder = SystemTextJson.GetAdncDefaultEncoder();
                //This value indicates whether comments are allowed, disallowed, or skipped.
                options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                //Dynamic and anonymous type serialization settings
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                //Dynamic
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                //Anonymous type
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

        Services
            .AddFluentValidationAutoValidation(cfg =>
            {
                //Continue validation failure, continue validating other items
                ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Continue;
                //cfg.ValidatorOptions.DefaultClassLevelCascadeMode = FluentValidation.CascadeMode.Continue;
                // Optionally set validator factory if you have problems with scope resolve inside validators.
                // cfg.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
            });

        Services
            .Configure<ApiBehaviorOptions>(options =>
            {
                //Adjust parameter validation return information format
                //Disable automatic validation
                //options.SuppressModelStateInvalidFilter = true;
                //Format validation information
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var problemDetails = new ProblemDetails
                    {
                        Detail = context.ModelState.GetValidationSummary("<br>"),
                        Title = "Parameter Error",
                        Status = (int)HttpStatusCode.BadRequest,
                        Type = "https://httpstatuses.com/400",
                        Instance = context.HttpContext.Request.Path
                    };

                    return new ObjectResult(problemDetails)
                    {
                        StatusCode = problemDetails.Status
                    };
                };
            });
    }
}
