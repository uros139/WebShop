using Enigmatry.Shop.DbAccess.Shop.Command;
using Enigmatry.Shop.Models;
using Enigmatry.Shop.Models.Extensions;
using MediatR;

namespace Enigmatry.Shop.Handlers;

public class BuyArticle : IRequest<Response<Article>>
{
    public BuyArticle(int id, int buyerId)
    {
        Id = id;
        BuyerId = buyerId;
    }

    public int Id { get; set; }
    public int BuyerId { get; set; }
}

public class BuyArticleHandler : IRequestHandler<BuyArticle, Response<Article>>
{
    private readonly Dictionary<int, Article> _cachedArticles;
    private readonly ArticleCommand _articleCommand;

    public BuyArticleHandler(Dictionary<int, Article> cachedArticles, ArticleCommand articleCommand)
    {
        _cachedArticles = cachedArticles;
        _articleCommand = articleCommand;
    }

    public async Task<Response<Article>> Handle(BuyArticle request, CancellationToken cancellationToken)
    {
        if (_cachedArticles.TryGetValue(request.Id, out var item))
        {
            var article = new Article
            {
                Id = item.Id,
                Price = item.Price,
                IsSold = true,
                SoldDate = DateTimeOffset.UtcNow,
                BuyerUserId = request.BuyerId
            };

           var success =  await _articleCommand.Save(article);
           return success ? ApiResponse.Ok(article) : ApiResponse.Fail(article, "Failed to complete transaction");
        }

        return ApiResponse.Fail(new Article
        {
            Id = request.Id
        }, $"There is no article with id: {request.Id}");

    }
}

