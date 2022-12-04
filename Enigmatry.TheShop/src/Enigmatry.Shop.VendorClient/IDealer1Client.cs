using Enigmatry.Shop.Models;
using Refit;

namespace Enigmatry.Shop.VendorClient;

public interface IDealer1Client
{
    [Get("/supplier")]
    Task<ApiResponse<Article?>> GetArticle(int id);
}
