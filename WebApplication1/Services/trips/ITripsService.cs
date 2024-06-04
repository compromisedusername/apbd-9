using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface ITripsService
{
     Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize, CancellationToken cancellationToken);
     Task<PageDTO> GetPagingInfo(int page, int pageSize, CancellationToken cancellationToken);

     Task<int> AssignClientToTrip(RequestAssignClientTrip data, CancellationToken cancellationToken);

}