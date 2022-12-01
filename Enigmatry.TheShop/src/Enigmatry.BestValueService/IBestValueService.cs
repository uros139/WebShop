using Enigmatry.VendorHttpClient.Models;

namespace Enigmatry.BestValueService;

public interface IBestValueService
{
    public Task<Article> GetBestValue(int id);
}
