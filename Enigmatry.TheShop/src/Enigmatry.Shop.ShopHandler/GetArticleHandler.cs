using Enigmatry.Shop.BestValueService;
using Enigmatry.Shop.Models;
using Enigmatry.Shop.Models.Extensions;
using MediatR;

namespace Enigmatry.Shop.Handlers;

public class GetArticle : IRequest<Response<Article>>
{
    public GetArticle(int id, int? maxPrice)
    {
        Id = id;
        MaxPrice = maxPrice;
    }

    public int Id { get; set; }
    public int? MaxPrice { get; set; }
}

public class GetArticleHandler : IRequestHandler<GetArticle, Response<Article>>
{
    private readonly IBestValueService _service;
    private readonly Dictionary<int, Article> _cachedArticles;

    public GetArticleHandler(IBestValueService service, Dictionary<int, Article> cachedArticles)
    {
        _service = service;
        _cachedArticles = cachedArticles;
    }

    public async Task<Response<Article>> Handle(GetArticle request, CancellationToken cancellationToken)
    {
        var (found, article) = await _service.GetBestValue(request.Id);
        if (!found && !_cachedArticles.ContainsKey(request.Id)) return ApiResponse.Fail(new Article(),"Not found");


        if (!_cachedArticles.ContainsKey(request.Id) && found) _cachedArticles.TryAdd(article.Id, article);

        if (_cachedArticles.TryGetValue(article.Id, out var cachedArticle))
        {
            if (cachedArticle.Price > article.Price)
            {
                _cachedArticles.Remove(article.Id);
                _cachedArticles.TryAdd(article.Id, article);
            }
        }

        if (request.MaxPrice is not null && article.Price >= request.MaxPrice)
            return ApiResponse.Fail(article, "Not found for that price");

        return ApiResponse.Ok(article);
    }
}
