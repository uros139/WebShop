using Enigmatry.VendorHttpClient.Models;

namespace Enigmatry.Cache.Shop;

public class SupplierCache
{
    private Dictionary<int, Article> _cachedArticles;

    public SupplierCache(Dictionary<int, Article> cachedArticles)
    {
        _cachedArticles = cachedArticles;
    }

    public async Task<(bool, Article)> GetArticle(int id)
    {
        var found = _cachedArticles.TryGetValue(id, out var article);
        return new(found, article);
    }

    public void SetArticle(Article article)
    {
        _cachedArticles.TryAdd(article.Id, article);
    }

    public bool ArticleInInventory(int id)
    {
        return _cachedArticles.ContainsKey(id);
    }
}
