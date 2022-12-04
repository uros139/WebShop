using Enigmatry.Shop.Models;

namespace Enigmatry.Shop.WareHouseService;

public class WareHouseService : IWareHouseService
{
    public bool ArticleInInventory(int id) => new Random().NextDouble() >= 0.5;

    public Article GetArticle(int id)
    {
        return new Article()
        {
            Id = id,
            Name = $"Article {id}",
            Price = new Random().Next(100, 500)
        };
    }
}
