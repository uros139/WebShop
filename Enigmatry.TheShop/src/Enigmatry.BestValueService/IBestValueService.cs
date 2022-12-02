using Enigmatry.Shop.VendorClient.Models;

namespace Enigmatry.Shop.BestValueService;

public interface IBestValueService
{
    public Task<Article> GetBestValue(int id);
}
