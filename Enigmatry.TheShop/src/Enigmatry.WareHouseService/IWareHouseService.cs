using Enigmatry.Shop.Models;

namespace Enigmatry.Shop.WareHouseService;

public interface IWareHouseService
{
    public bool ArticleInInventory(int id);

    public Article GetArticle(int id);
}


