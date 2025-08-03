using Dkd.Shared.Remote.Http;

namespace Dkd.App.Remote.Http.Services;

public interface IWhseRestClient : IRestClient
{
    /// <summary>
    /// Get product list from warehouse service
    /// </summary>
    /// <returns></returns>
    [Headers("Authorization: Basic", "Cache: 1000")]
    [Get("/whse/api/products")]
    Task<List<ProductResponse>> GetProductsAsync(ProductSearchRequest input, CancellationToken cancellationToken = default);
}
