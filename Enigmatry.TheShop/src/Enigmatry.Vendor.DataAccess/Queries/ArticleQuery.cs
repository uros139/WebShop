using Enigmatry.Vendor.Models;

namespace Enigmatry.Vendor.DataAccess.Queries;

// Article DB Queries MOCK

public class ArticleQuery
{
    private List<Article> _articles;

    public ArticleQuery(List<Article> articles)
    {
        _articles = articles;   
    }

    public async Task<Article?> GetById(int id)
    {
        return await Task.FromResult(_articles.SingleOrDefault(x => x.Id == id));
    }
}