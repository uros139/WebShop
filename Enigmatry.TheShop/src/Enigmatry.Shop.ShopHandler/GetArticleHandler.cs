using Enigmatry.Shop.BestValueService;
using Enigmatry.Shop.VendorClient.Models;
using MediatR;

namespace Enigmatry.Shop.Handlers;

public class GetArticle : IRequest<Article>
{
    public GetArticle(int id, int maxPrice)
    {
        Id = id;
        MaxPrice = maxPrice;
    }

    public int Id { get; set; }
    public int MaxPrice { get; set; }
}

public class GetArticleHandler : IRequestHandler<GetArticle, Article>
{
    private readonly IBestValueService _service;

    public GetArticleHandler(IBestValueService service)
    {
        _service = service;
    }

    public async Task<Article> Handle(GetArticle request, CancellationToken cancellationToken)
    {
        var article = await _service.GetBestValue(request.Id);
        return article;
    }
}
