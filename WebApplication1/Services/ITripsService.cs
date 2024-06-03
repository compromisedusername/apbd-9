using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services;

public interface ITripsService
{
    public Task<IActionResult> GetTrips(int page, int pageSize);

}