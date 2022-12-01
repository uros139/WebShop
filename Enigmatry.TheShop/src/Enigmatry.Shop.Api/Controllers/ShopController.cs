using Enigmatry.Shop.Api.Dto;
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
    public Task<ActionResult<Article>> GetArticle(int id, int maxExpectedPrice = 200)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<ActionResult> BuyArticle(Article article, int buyerId)
    {
        throw new NotImplementedException();
    }
}
