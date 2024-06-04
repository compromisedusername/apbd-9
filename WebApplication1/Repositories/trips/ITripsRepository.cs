using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface ITripsRepository

{
     Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize, CancellationToken cancellationToken);
     Task<PageDTO> GetPagingInfo(int pageSize, int page, CancellationToken cancellationToken);


     Task<bool> IsTripInFutureAndExists(int dataIdTrip, CancellationToken cancellationToken);
     Task<bool> IsTripPaidByClient(int dataIdTrip, string dataPesel, CancellationToken cancellationToken);
}