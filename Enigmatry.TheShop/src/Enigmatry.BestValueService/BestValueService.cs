using Enigmatry.Shop.DbAccess.Shop.Command;
using Enigmatry.VendorHttpClient;
using Enigmatry.VendorHttpClient.Models;
using Enigmatry.WareHouseService;
using Microsoft.Extensions.Logging;

namespace Enigmatry.BestValueService;

public class BestValueService : IBestValueService
{
    private Dictionary<int, Article> _articlesCache;
    private readonly IWareHouseService _wareHouseService;
    private readonly IDealer1Client _firstDealer;
    private readonly IDealer2Client _secondDealer;
    private readonly ArticleQuery _articleQuery;
    private readonly ILogger<BestValueService> _logger;

    public BestValueService(IWareHouseService wareHouseService, IDealer1Client firstDealer, IDealer2Client secondDealer, Dictionary<int, Article> articlesCache, ArticleQuery articleQuery, ILogger<BestValueService> logger)
    {
        _wareHouseService = wareHouseService;
        _firstDealer = firstDealer;
        _secondDealer = secondDealer;
        _articleQuery = articleQuery;
        _articlesCache = articlesCache;
        _logger = logger;
    }

    public async Task<Article> GetBestValue(int id)
    {
        var articles = new List<Article>();
        try
        {
            if (_wareHouseService.ArticleInInventory(id))
                articles.Add(_wareHouseService.GetArticle(id));

            _logger.LogInformation("Trying to retrieve article from dealer 1");
            var response1 = await _firstDealer.GetArticle(id);

            switch (response1.IsSuccessStatusCode)
            {
                case true when response1.Content != null:
                    articles.Add(response1.Content);
                    break;
                case false:
                    _logger.LogWarning($"Failed to get article from dealer 1: {response1.Error}");
                    break;
            }

            _logger.LogInformation("Trying to retrieve article from dealer 1");
            var response2 = await _secondDealer.GetArticle(id);

            switch (response2.IsSuccessStatusCode)
            {
                case true when response2.Content != null:
                    articles.Add(response2.Content);
                    break;
                case false:
                    _logger.LogWarning($"Failed to get article from dealer 2: {response2.Error}");
                    break;
            }

            var (found, article) = _articleQuery.GetById(id);

            if (found && article is not null)
                articles.Add(article);
            else _logger.LogInformation("Could not get article from db");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to get best value article: {ex.Message}");
            throw new Exception(ex.Message);
        }

        return articles.MinBy(x => x.Price);
    }
}
