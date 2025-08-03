using Dkd.Shared.WebApi.AutoWrapper.Wrappers;
using Swashbuckle.AspNetCore.SwaggerGen;


public class AutoWrapperOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var actionReturnType = context.MethodInfo.ReturnType;

        if (actionReturnType.IsGenericType && actionReturnType.GetGenericTypeDefinition() == typeof(ActionResult<>))
        {
            var innerType = actionReturnType.GetGenericArguments()[0];
            
            // ساخت نوع ApiResponse<T> به صورت داینامیک
            var wrapperType = typeof(ApiResponse<>).MakeGenericType(innerType);

            foreach (var response in operation.Responses)
            {
                // فقط برای کدهای موفق (2xx) از ApiResponse<T> استفاده می‌کنیم
                if (response.Key.StartsWith("2"))
                {
                    response.Value.Content.Clear();
                    response.Value.Content["application/json"] = new OpenApiMediaType
                    {
                        Schema = context.SchemaGenerator.GenerateSchema(wrapperType, context.SchemaRepository)
                    };
                }
                else
                {
                    // برای کدهای خطا از ApiResponse معمولی استفاده می‌کنیم
                    response.Value.Content.Clear();
                    response.Value.Content["application/json"] = new OpenApiMediaType
                    {
                        Schema = context.SchemaGenerator.GenerateSchema(typeof(ApiResponse), context.SchemaRepository)
                    };
                }
            }
        }
    }
}
