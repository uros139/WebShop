using Enigmatry.Vendor.Models;
using Microsoft.Extensions.Logging;

namespace Enigmatry.Vendor.DataAccess.Commands;

// Article DB Commands MOCK

public class ArticleCommand
{
    private List<Article> _articles;
    private readonly ILogger<ArticleCommand> _logger;

    public ArticleCommand(List<Article> articles, ILogger<ArticleCommand> logger)
    {
        _articles = articles;
        _logger = logger;
    }

    public Task<bool> Save(Article article)
    {
        try
        {
            _logger.LogInformation($"Trying to save article : {article.Id}");
            _articles.Add(article);
            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to save article : {article.Id}, message : {ex.Message}");
            return Task.FromResult(true);
        }
    }
}
