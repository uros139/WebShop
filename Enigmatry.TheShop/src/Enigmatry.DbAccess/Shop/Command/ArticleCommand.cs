using Enigmatry.Shop.Models;
using Microsoft.Extensions.Logging;

namespace Enigmatry.Shop.DbAccess.Shop.Command;

public class ArticleCommand
{
    private readonly List<Article> _articles;
    private readonly ILogger<ArticleCommand> _logger;

    public ArticleCommand(List<Article> articles, ILogger<ArticleCommand> logger)
    {
        _articles = articles;
        _logger = logger;
    }

    public void Save(Article article)
    {
        try
        {
            _articles.Add(article);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while saving article {ex.Message}");
            throw new Exception($"Error :{ex.Message}");
        }

    }
}
