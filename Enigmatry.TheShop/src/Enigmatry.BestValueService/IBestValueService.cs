using Enigmatry.Shop.Models;

namespace Enigmatry.Shop.BestValueService;

public interface IBestValueService
{
    public Task<(bool, Article?)> GetBestValue(int id);
}
