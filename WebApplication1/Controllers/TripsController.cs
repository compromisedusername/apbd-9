using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ITripsService  _tripsService;

    public TripsController(ITripsService tripsService)
    {
        _tripsService = tripsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "pageSize")] int pageSize = 10)
    {
        var result =
            new
            {
                pagingInfo = await _tripsService.GetPagingInfo(page, pageSize),
                trips = await _tripsService.GetTrips(page, pageSize)
            };
        return Ok(result);
    }
    

}
