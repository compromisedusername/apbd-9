using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface ITripsRepository
{
    public Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize);
    public Task<PageDTO> GetPagingInfo(int pageSize, int page);


}