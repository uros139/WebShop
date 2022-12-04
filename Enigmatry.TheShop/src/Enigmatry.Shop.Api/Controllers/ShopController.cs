using Enigmatry.Shop.Api.Dto;
using Enigmatry.Shop.Handlers;
using Enigmatry.Shop.Models;
using Enigmatry.Shop.Models.Extensions;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Enigmatry.Shop.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ShopController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}/get-article")]
    public async Task<ActionResult<Response<ArticleDto>>> GetArticle(int id, [FromQuery] int? maxExpectedPrice)
    {
        var result = await _mediator.Send(new GetArticle(id, maxExpectedPrice));
        return Ok(result.Adapt<Response<ArticleDto>>());
    }

    [HttpPost("{buyerId}/buy")]
    public async Task<ActionResult<Response<Article>>> BuyArticle(int buyerId, [FromBody] BuyArticleDto request)
    {
        var result = await _mediator.Send(new BuyArticle(request.Id, request.Price, buyerId));
        return Ok(result);
    }
}