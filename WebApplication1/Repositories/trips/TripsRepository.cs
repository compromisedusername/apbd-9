using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Repositories;

public class TripsRepository : BaseRepository, ITripsRepository
{

    public async Task<PageDTO> GetPagingInfo(int page, int pageSize, CancellationToken cancellationToken)
    {
        var totalTrips = await _unitOfWork.Context.Trips.CountAsync(cancellationToken);
        
        var allPages = (int)Math.Ceiling(totalTrips / (double)pageSize);

        return new PageDTO
        {
            AllPages = allPages,
            PageSize = pageSize,
            PageNum = page
        };
    }

    public async Task<bool> IsTripInFutureAndExists(int dataIdTrip, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Context.Trips.AnyAsync(e => e.DateFrom >= DateTime.Now && e.IdTrip == dataIdTrip, cancellationToken);
    }

    public async Task<bool> IsTripPaidByClient(int dataIdTrip, string dataPesel, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Context.ClientTrips.AnyAsync(e =>
            e.IdClientNavigation.Pesel.Equals(dataPesel) && e.IdTrip == dataIdTrip && e.PaymentDate != null, cancellationToken);
    }


    public async Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize, CancellationToken cancellationToken)
    {
        var trips = await _unitOfWork.Context.Trips.Select(e => new TripDTO()
            {
                Name = e.Name,
                DateFrom = e.DateFrom,
                MaxPeople = e.MaxPeople,
                Clients = e.ClientTrips.Select(e => new ClientDTO()
                {
                    FirstName = e.IdClientNavigation.FirstName,
                    LastName = e.IdClientNavigation.LastName,
                    Email = e.IdClientNavigation.Email,
                    Pesel = e.IdClientNavigation.Pesel,
                    Telephone = e.IdClientNavigation.Telephone
                })
            })
            .Skip((page-1) * pageSize)
            .Take(pageSize)
            .OrderBy(e=>e.DateFrom)
            .ToListAsync(cancellationToken);

        return trips;
    }


    public TripsRepository( IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}