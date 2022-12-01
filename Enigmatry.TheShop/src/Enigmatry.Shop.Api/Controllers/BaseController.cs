using Microsoft.AspNetCore.Mvc;

namespace Enigmatry.Shop.Api.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected ActionResult<T> OkOrNotFound<T>(T result)
    {
        if (result is null) return NotFound(null);
        return Ok(result);
    }
}
