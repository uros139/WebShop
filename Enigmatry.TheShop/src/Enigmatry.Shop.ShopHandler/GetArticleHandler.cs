using Enigmatry.VendorHttpClient.Models;
using MediatR;

namespace Enigmatry.ShopHandlers;

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
    public Task<Article> Handle(GetArticle request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
