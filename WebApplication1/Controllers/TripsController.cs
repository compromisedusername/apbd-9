using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    

    [HttpGet]
    public async Task<IActionResult> GetTrips([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "pageSize")] int pageSize = 10)
    {
        
        // todo Wydzielic do serwisu ;)
        if ( page <= 0)
        {
            return BadRequest("Invalid 'page' parameter. It must be a positive integer.");
        }if ( pageSize <= 0)
        {
            return BadRequest("Invalid 'pageSize' parameter. It must be a positive integer.");
        }
        
        
    }

}
