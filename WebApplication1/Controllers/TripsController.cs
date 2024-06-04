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
    public async Task<IActionResult> GetTrips(CancellationToken cancellationToken, [FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "pageSize")] int pageSize = 10)
    {
        var result =
            new
            {
                pagingInfo = await _tripsService.GetPagingInfo(page, pageSize, cancellationToken),
                trips = await _tripsService.GetTrips(page, pageSize, cancellationToken)
            };
        return Ok(result);
    }
    [HttpPost("{idTrip:int}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, RequestAssignClientTripDTO requestDTO, CancellationToken cancellationToken)
    {

        var data = new RequestAssignClientTrip()
        {
            Email = requestDTO.Email,
            FirstName = requestDTO.FirstName,
            IdTrip = idTrip,
            LastName = requestDTO.LastName,
            PaymentDate = requestDTO.PaymentDate,
            Pesel = requestDTO.Pesel,
            Telephone = requestDTO.Telephone,
            TripName = requestDTO.TripName
        };
        return Ok(new
        {
            idClient = await _tripsService.AssignClientToTrip(data, cancellationToken),
            idTrip = data.IdTrip
        });
    }
    

}
