using Enigmatry.Vendor.Api.Dto;
using Enigmatry.Vendor.Handlers;
using Enigmatry.Vendor.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Enigmatry.Vendor.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SupplierController : BaseController
{
    private readonly ILogger<SupplierController> _logger;
    private readonly IMediator _mediator;

    public SupplierController(ILogger<SupplierController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ArticleDto?>> GetArticle(int id)
    {
        var article = await _mediator.Send(new GetArticle(id));
        return OkOrNotFound(article.Adapt<ArticleDto?>());
    }

    [HttpPost("{buyerId}/buy")]
    public async Task<ActionResult<Article>> BuyArticle(int buyerId, [FromBody] ArticleDto request)
    {
        var result = await _mediator.Send(new BuyArticle(request.Id, request.Name, request.Price, buyerId));
        return OkOrNotFound(result);
    }
}
