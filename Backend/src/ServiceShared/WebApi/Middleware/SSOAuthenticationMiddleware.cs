using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace Adnc.Shared.WebApi.Middleware;

public class SsoAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JWTOptions _jwtConfig;
    private readonly string tokenPrefx = "accesstoken";
    private readonly ICacheProvider _cache;

    public SsoAuthenticationMiddleware(RequestDelegate next
        , IOptions<JWTOptions> jwtConfig
        , ICacheProvider cache)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _cache = cache;
        _jwtConfig = jwtConfig.Value;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        var endpoint = context.GetEndpoint();
        if (endpoint == null)
        {
            await _next(context);
            return;
        }

        var requiredValues = ((RouteEndpoint)endpoint).RoutePattern.RequiredValues;
        if (!requiredValues.Any())
        {
            await _next(context);
            return;
        }

        var controller = requiredValues["controller"]?.ToString().ToLower();
        var action = requiredValues["action"]?.ToString().ToLower();
        if (controller.IsNullOrWhiteSpace())
        {
            await _next(context);
            return;
        }

        var statusCode = (HttpStatusCode)context.Response.StatusCode;

        //Check if API needs authentication
        bool isNeedAuthentication = endpoint.Metadata.GetMetadata<IAllowAnonymous>() == null;

        //API does not need authentication
        if (!isNeedAuthentication)
        {
            //If it's calling login API or refresh token API, and the call is successful, need to save accesstoken to cache
            if (controller == "account" && (action == "login" || action == "refreshaccesstoken"))
            {
                await SaveToken(context, _next);
                return;
            }

            //Other APIs
            await _next(context);
            return;
        }

        //API needs authentication
        if (isNeedAuthentication)
        {
            //If it's changing password, need to remove Token from cache
            if (controller == "account" && action == "password")
            {
                await _next(context);
                if (statusCode.Is2xx())
                    await RemoveToken(context);
                return;
            }

            //If it's logout, need to check if it's active logout
            if (controller == "account" && action == "logout")
            {
                await _next(context);
                if (statusCode.Is2xx())
                {
                    //Active logout, remove token from cache
                    if (await CheckToken(context))
                        await RemoveToken(context);
                    return;
                }
            }
        }

        //API needs authentication, and if it's successful, need to check if accesstoken is in cache.
        if (statusCode.Is2xx())
        {
            //Need to first check if token is the latest before going to other middlewares
            var result = await CheckToken(context);
            if (result)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
                return;
            }
            else
            {
                var status = (int)HttpStatusCode.Unauthorized;
                var hostAndPort = context.Request.Host.HasValue ? context.Request.Host.Value : string.Empty;
                var requestUrl = string.Concat(hostAndPort, context.Request.Path);
                var type = string.Concat("https://httpstatuses.com/", status);
                var title = "Token already expired";
                var detial = "Token already expired, please log in again";
                var problemDetails = new ProblemDetails
                {
                    Title = title
                    ,
                    Detail = detial
                    ,
                    Type = type
                    ,
                    Status = status
                    ,
                    Instance = requestUrl
                };
                context.Response.StatusCode = status;
                context.Response.ContentType = "application/problem+json";
                var stream = context.Response.Body;
                await JsonSerializer.SerializeAsync(stream, problemDetails);
                return;
            }
        }

        await _next(context);
    }

    /// <summary>
    /// Save token
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    private async Task SaveToken(HttpContext context, RequestDelegate next)
    {
        string responseContent;

        var originalBodyStream = context.Response.Body;

        using (var fakeResponseBody = new MemoryStream())
        {
            context.Response.Body = fakeResponseBody;

            await next(context);

            fakeResponseBody.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(fakeResponseBody))
            {
                responseContent = await reader.ReadToEndAsync();
                fakeResponseBody.Seek(0, SeekOrigin.Begin);

                await fakeResponseBody.CopyToAsync(originalBodyStream);
            }
        }

        var statusCode = (HttpStatusCode)context.Response.StatusCode;

        if (statusCode.Is2xx())
        {
            //var tokenTxt = JObject.Parse(responseContent).GetValue("token")?.ToString();
            var tokenTxt = string.Empty;
            if (tokenTxt.IsNullOrWhiteSpace())
                return;
            //refreshTokenTxt = JObject.Parse(responseContent).GetValue("refreshToken").ToString();

            var claimsInfo = GetClaimsInfo(tokenTxt);
            if (claimsInfo.Account.IsNotNullOrWhiteSpace())
            {
                var tokenKey = $"{tokenPrefx}:{claimsInfo.Account}:{claimsInfo.Id}";
                _cache.Set(tokenKey, claimsInfo.Token, claimsInfo.Expire - DateTime.Now);
                //var refreshTokenKey = $"{refreshTokenPrefx}:{claimsInfo.Account}:{claimsInfo.Id}";
                //_cache.Set(refreshTokenKey, refreshTokenTxt, TimeSpan.FromSeconds(_jwtConfig.RefreshTokenExpire));
            }
        }
    }

    /// <summary>
    /// 移除token
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private async Task RemoveToken(HttpContext context)
    {
        var tokenTxt = await context.GetTokenAsync("access_token");
        if (string.IsNullOrWhiteSpace(tokenTxt))
        {
            await Task.CompletedTask;
            return;
        }

        var claimsInfo = GetClaimsInfo(tokenTxt);
        if (claimsInfo.Account.IsNotNullOrWhiteSpace())
        {
            var tokenKey = $"{tokenPrefx}:{claimsInfo.Account}:{claimsInfo.Id}";
            //var refreshTokenKey = $"{refreshTokenPrefx}:{claimsInfo.Account}:{claimsInfo.Id}";
            //await _cache.RemoveAllAsync(new List<string>() { key, refreshTokenKey });
            await _cache.RemoveAsync(tokenKey);
        }
    }

    /// <summary>
    /// 检查token
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private async Task<bool> CheckToken(HttpContext context)
    {
        var tokenTxt = await context.GetTokenAsync("access_token");
        if (string.IsNullOrWhiteSpace(tokenTxt))
            return await Task.FromResult(false);

        var claimsInfo = GetClaimsInfo(tokenTxt);
        if (claimsInfo.Account.IsNotNullOrEmpty())
        {
            var tokenKey = $"{tokenPrefx}:{claimsInfo.Account}:{claimsInfo.Id}";
            var cahceToken = _cache.Get<string>(tokenKey).Value;
            return (cahceToken == claimsInfo.Token);
        }
        return false;
    }

    /// <summary>
    /// 解析token
    /// </summary>
    /// <param name="tokenTxt"></param>
    /// <returns></returns>
    private (string Account, long Id, DateTime Expire, string Token) GetClaimsInfo(string tokenTxt)
    {
        if (tokenTxt.IsNotNullOrWhiteSpace())
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenTxt);
            if (token != null)
            {
                var expireTimestamp = token.Claims.FirstOrDefault(p => p.Type == "exp").Value.ToLong();
                var expireDt = expireTimestamp.Value.ToLocalTime().AddSeconds(_jwtConfig.ClockSkew);
                var Id = token.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value.ToLong();
                var account = token.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

                return (Account: account, Id: Id.Value, Expire: expireDt, Token: tokenTxt);
            }
        }

        return (null, 0, DateTime.Now, null);
    }
}

/// <summary>
/// 注册单点登录中间件
/// </summary>
[Obsolete("已经废弃")]
public static class SsoAuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseSSOAuthentication(this IApplicationBuilder builder, bool isOpenSSOAuthentication = true)
    {
        if (isOpenSSOAuthentication)
            throw new NullReferenceException(nameof(isOpenSSOAuthentication));
            //return builder.UseMiddleware<SsoAuthenticationMiddleware>();

        return builder;
    }
}
