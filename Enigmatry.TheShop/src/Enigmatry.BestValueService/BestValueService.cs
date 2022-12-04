using Enigmatry.Shop.DbAccess.Shop.Query;
using Enigmatry.Shop.Models;
using Enigmatry.Shop.VendorClient;
using Enigmatry.Shop.WareHouseService;
using Microsoft.Extensions.Logging;
using Refit;

namespace Enigmatry.Shop.BestValueService;

public class BestValueService : IBestValueService
{
    private readonly Dictionary<int, Article?> _cachedArticles;
    private readonly IWareHouseService _wareHouseService;
    private readonly IDealer1Client _firstDealerClient;
    private readonly IDealer2Client _secondDealerClient;
    private readonly ArticleQuery _articleQuery;
    private readonly ILogger<BestValueService> _logger;

    public BestValueService(IWareHouseService wareHouseService, IDealer1Client firstDealerClient, IDealer2Client secondDealerClient, Dictionary<int, Article?> cachedArticles, ArticleQuery articleQuery, ILogger<BestValueService> logger)
    {
        _wareHouseService = wareHouseService;
        _firstDealerClient = firstDealerClient;
        _secondDealerClient = secondDealerClient;
        _articleQuery = articleQuery;
        _cachedArticles = cachedArticles;
        _logger = logger;
    }

    public async Task<(bool, Article?)> GetBestValue(int id)
    {
        var articles = new List<Article?>();

        if (_wareHouseService.ArticleInInventory(id))
            articles.Add(_wareHouseService.GetArticle(id));

        var (found, article) = _articleQuery.GetById(id);

        if (found)
            articles.Add(article);
        else _logger.LogInformation("Could not get article from db");

        var (dealer1Found, article1) = await GetArticleFromDealer1(id);
        if (dealer1Found) articles.Add(article1);

        var (dealer2Found, article2) = await GetArticleFromDealer1(id);
        if (dealer2Found) articles.Add(article2);

        if (_cachedArticles.TryGetValue(id, out Article? cachedArticle))
        {
            articles.Add(cachedArticle);
        }

        var articleMinPrice = articles.MinBy(x => x.Price);

        if (articleMinPrice is not null) return (true, articleMinPrice);

        _logger.LogWarning("Unable to retrieve article");
        return (false, new Article());

    }

    private async Task<(bool, Article?)> GetArticleFromDealer1(int id)
    {

        var found = false;
        Article? article = new Article();
        try
        {
            _logger.LogInformation("Trying to retrieve article from dealer 1");
            var response = await _firstDealerClient.GetArticle(id);

            switch (response.IsSuccessStatusCode)
            {
                case true when response.Content != null:
                    found = true;
                    article = response.Content;
                    break;
                case false:
                    _logger.LogWarning($"Failed to get article from dealer 1: {response.Error}");
                    break;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get article from dealer 1:{ex.Message}");
            return (false, null);
        }

        return (found, article);
    }

    private async Task<(bool, Article)> GetArticleFromDealer2(int id)
    {
        var found = false;
        Article article = new Article();
        try
        {
            _logger.LogInformation("Trying to retrieve article from dealer 2");
            var response = await _secondDealerClient.GetArticle(id);

            switch (response.IsSuccessStatusCode)
            {
                case true when response.Content != null:
                    found = true;
                    article = response.Content;
                    break;
                case false:
                    _logger.LogWarning($"Failed to get article from dealer 2: {response.Error}");
                    break;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get article from dealer 2:{ex.Message}");
            return (false, null);
        }

        return (found, article);
    }


}
