using Enigmatry.Shop.Models;
using Enigmatry.Shop.VendorClient.Models;
using Refit;

namespace Enigmatry.Shop.VendorClient;

public interface IDealer1Client
{
    [Get("/supplier")]
    Task<ApiResponse<GetArticleResponse>> GetArticle(int id);
}
