using Enigmatry.VendorHttpClient.Models;
using Refit;

namespace Enigmatry.VendorHttpClient;

public interface IDealer1Client
{
    [Get("/supplier")]
    ApiResponse<Task<Article>> GetArticle();
}
