using Enigmatry.Shop.Models;
using Refit;

namespace Enigmatry.Shop.VendorClient;

public interface IDealer2Client
{
    [Get("/supplier")]
    Task<ApiResponse<Article>> GetArticle(int id);
}
