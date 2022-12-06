using BeelineTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace BeelineTest.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ValuteValueController  : ControllerBase
{
    
    /// <summary>
    /// Get Valute value by char code.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Valute value.</returns>
    /// <response code="200">Returns Valute value.</response>
    [HttpGet(Name = "GetValuteValue")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] string charCode, [FromServices] DataService dataService,
        CancellationToken cancellationToken)
        => Ok(await dataService.GetValuteValue(charCode, cancellationToken));
}