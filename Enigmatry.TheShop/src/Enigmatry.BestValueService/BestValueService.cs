using Enigmatry.Shop.Dealer1Service;
using Enigmatry.Shop.Models;
using Enigmatry.Shop.WareHouseService;
using Microsoft.Extensions.Logging;

namespace Enigmatry.Shop.BestValueService;

public class BestValueService : IBestValueService
{
    private readonly Dictionary<int, Article> _cachedArticles;
    private readonly IWareHouseService _wareHouseService;
    private readonly IDealer1Service _firstDealerService;
    private readonly IDealer1Service _secondDealerService;
    private readonly ILogger<BestValueService> _logger;

    public BestValueService(Dictionary<int, Article> cachedArticles, IWareHouseService wareHouseService, IDealer1Service firstDealerService, IDealer1Service secondDealerService, ILogger<BestValueService> logger)
    {
        _cachedArticles = cachedArticles;
        _wareHouseService = wareHouseService;
        _firstDealerService = firstDealerService;
        _secondDealerService = secondDealerService;
        _logger = logger;   
    }
    public async Task<(bool, Article)> GetBestValue(int id)
    {
        //get articles from all sources, then get get one with lowest price
       
        var articles = new List<Article>();

        if (_wareHouseService.ArticleInInventory(id))
            articles.Add(_wareHouseService.GetArticle(id));

        var (dealer1Found, article1) = await _firstDealerService.GetArticle(id);
        if (dealer1Found) articles.Add(article1);

        var (dealer2Found, article2) = await _secondDealerService.GetArticle(id);
        if (dealer2Found) articles.Add(article2);

        if (_cachedArticles.TryGetValue(id, out var cachedArticle))
        {
            articles.Add(cachedArticle);
        }

        var articleMinPrice = articles.MinBy(x => x.Price);

        if (articleMinPrice is not null) return (true, articleMinPrice);
        
        _logger.LogWarning("Unable to retrieve article");
        return (false, new Article());

    }
}
