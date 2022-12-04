using Enigmatry.Shop.Models;

namespace Enigmatry.Shop.Dealer1Service;

public interface IDealer1Service
{
    Task<(bool, Article)> GetArticle(int id);

}
