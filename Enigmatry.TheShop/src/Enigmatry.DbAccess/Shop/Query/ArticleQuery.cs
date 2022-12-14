using Enigmatry.Shop.Models;
using Microsoft.Extensions.Logging;

namespace Enigmatry.Shop.DbAccess.Shop.Query;

//DB Queries MOCK

public class ArticleQuery
{
    private readonly List<Article> _articles;
    private readonly ILogger<ArticleQuery> _logger;


    public ArticleQuery(List<Article> articles, ILogger<ArticleQuery> logger)
    {
        _articles = articles;
        _logger = logger;
    }

    public (bool, Article?) GetById(int id)
    {
        try
        {
            var article = _articles.SingleOrDefault(x => x.Id == id);

            var found = article != null;
            if (article != null) return (found, article);
            _logger.LogError($"Error while retrieving article: {id}");
            return (false, null);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while retrieving article: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }

}
