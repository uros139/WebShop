using Enigmatry.VendorHttpClient.Models;

namespace Enigmatry.WareHouseService;

public class WareHouseService : IWareHouseService
{
    public bool ArticleInInventory(int id) => new Random().NextDouble() >= id;

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
