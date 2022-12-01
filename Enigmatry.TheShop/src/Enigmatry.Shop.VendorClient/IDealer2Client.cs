using Enigmatry.VendorHttpClient.Models;
using Refit;

namespace Enigmatry.VendorHttpClient;

public interface IDealer2Client
{
    [Get("/supplier")]
    Task<ApiResponse<Article>> GetArticle(int id);
}
