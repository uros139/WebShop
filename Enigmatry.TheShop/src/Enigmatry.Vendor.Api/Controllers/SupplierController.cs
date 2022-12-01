using Enigmatry.Vendor.Api.Dto;
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
    public Task<ActionResult> GetArticle(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("is-article-available")]
    public Task<ActionResult<bool>> ArticleInInventory(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<ActionResult> BuyArticle(ArticleDto article, int buyerId)
    {
        throw new NotImplementedException();
    }
}
