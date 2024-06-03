using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class TripsService : ITripsService
{
    private ITripsRepository _repository;

    public TripsService(ITripsRepository repository)
    {
        _repository = repository;
    }

    public Task<IActionResult> GetTrips(int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}