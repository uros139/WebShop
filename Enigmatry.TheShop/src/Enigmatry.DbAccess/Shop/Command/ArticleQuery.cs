using Enigmatry.Shop.VendorClient.Models;
using Microsoft.Extensions.Logging;

namespace Enigmatry.Shop.DbAccess.Shop.Command;

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

    public (bool, Article) GetById(int id)
    {
        try
        {
            var article = _articles.SingleOrDefault(x => x.Id == id);

            var found = article != null;
            return new(found, article);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while retreiving article: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }

}
