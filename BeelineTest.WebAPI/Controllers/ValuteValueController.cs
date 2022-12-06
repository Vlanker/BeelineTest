using BeelineTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace BeelineTest.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ValuteValueController  : ControllerBase
{
    [HttpGet(Name = "GetValuteValue")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] string charCode, [FromServices] DataService dataService,
        CancellationToken cancellationToken)
        => Ok(await dataService.GetValuteValue(charCode, cancellationToken));
}