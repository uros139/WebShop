using Enigmatry.Shop.Models;

namespace Enigmatry.Shop.Dealer2Service;

public interface IDealer2Service
{
    Task<(bool, Article)> GetArticle(int id);
}
