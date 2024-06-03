using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Repositories;

public class TripsRepository : ITripsRepository
{
    private readonly ScaffoldContext _context;

    public TripsRepository(ScaffoldContext context)
    {
        _context = context;
    }


    public async Task<PageDTO> GetPagingInfo(int pageSize, int page)
    {
        var totalTrips = await _context.Trips.CountAsync();
        
        var allPages = (int)Math.Ceiling(totalTrips / (double)pageSize);

        return new PageDTO
        {
            AllPages = allPages,
            PageSize = pageSize,
            PageNum = page
        };
    }
    
    
    public async Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize)
    {
        var totalTrips = await _context.Trips.CountAsync();
        
        var allPages = (int)Math.Ceiling(totalTrips / (double)pageSize);

        
        var trips = await _context.Trips.Select(e => new TripDTO()
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
            .ToListAsync();

        return trips;
    }

    
}