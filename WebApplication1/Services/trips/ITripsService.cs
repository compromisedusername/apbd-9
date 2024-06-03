using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface ITripsService
{
    public Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize);
    public Task<PageDTO> GetPagingInfo(int page, int pageSize);

}