using Enigmatry.Shop.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Enigmatry.Shop.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ShopController : BaseController
{
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
