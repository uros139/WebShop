using Enigmatry.Vendor.DataAccess.Commands;
using Enigmatry.Vendor.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Enigmatry.Vendor.Handlers;

public class BuyArticle : IRequest<Article>
{
    public BuyArticle(int id, string name, int price, int buyerId)
    {
        Id = id;
        Name = name;
        Price = price;
        BuyerId = buyerId;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int BuyerId { get; set; }
}

public class BuyArticleHandler : IRequestHandler<BuyArticle, Article?>
{
    private readonly ArticleCommand _command;
    private readonly ILogger<BuyArticleHandler> _logger;

    public BuyArticleHandler(ArticleCommand command, ILogger<BuyArticleHandler> logger)
    {
        _command = command;
        _logger = logger;
    }

    public async Task<Article?> Handle(BuyArticle request, CancellationToken cancellationToken)
    {
        if (request.BuyerId < 1 || request.Id < 1 || request.Name.Length < 1 || request.Price <= 0)
        {
            _logger.LogWarning($"Bad request by user : {request.BuyerId}");
            return null;
        }

        var article = new Article()
        {
            Id = request.Id,
            Name = request.Name,
            Price = request.Price,
            IsSold = true,
            SoldDate = DateTimeOffset.UtcNow,
            BuyerUserId = request.BuyerId
        };

        var success = await _command.Save(article);

        return success ? article : null;
    }
}
