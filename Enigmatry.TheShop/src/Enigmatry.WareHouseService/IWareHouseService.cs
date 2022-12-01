using Enigmatry.VendorHttpClient.Models;

namespace Enigmatry.WareHouseService;

public interface IWareHouseService
{
    public bool ArticleInInventory(int id);

    public Article GetArticle(int id);
}


