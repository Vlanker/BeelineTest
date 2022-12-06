using BeelineTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace BeelineTest.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ValuteController : ControllerBase
{
    
    /// <summary>
    /// Get Valute list.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of available currencies.</returns>
    /// <response code="200">Returns list of available currencies.</response>
    [HttpGet(Name = "GetNameValutes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromServices] DataService dataService, CancellationToken cancellationToken)
        => Ok(await dataService.GetNameValutesAsync(cancellationToken));
}