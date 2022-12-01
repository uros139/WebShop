using Enigmatry.Vendor.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Enigmatry.Vendor.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SupplierController : BaseController
{
    [HttpGet]
    public Task<ActionResult<bool>> ArticleInInventory(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<ActionResult> GetArticle(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<ActionResult> BuyArticle(Article article, int buyerId)
    {
        throw new NotImplementedException();
    }
}
