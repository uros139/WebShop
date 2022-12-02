using Enigmatry.Shop.Api.Dto;
using Enigmatry.Shop.Handlers;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Enigmatry.Shop.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ShopController : BaseController
{
    private readonly ILogger<ShopController> _logger;
    private readonly IMediator _mediator;

    public ShopController(ILogger<ShopController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ArticleDto>> GetArticle(int id, int maxExpectedPrice = 200)
    {
        var result = await _mediator.Send(new GetArticle(id, maxExpectedPrice));
        return OkOrNotFound(result.Adapt<ArticleDto>());
    }

    [HttpPost]
    public Task<ActionResult> BuyArticle(ArticleDto article, int buyerId)
    {
        throw new NotImplementedException();
    }
}
