using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class TripsService : ITripsService
{
    private ITripsRepository _repository;

    public TripsService(ITripsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize)
    {
        return await _repository.GetTrips(page, pageSize);
    }

    public async Task<PageDTO> GetPagingInfo(int page, int pageSize)
    {
        if ( page <= 0)
        {
            throw new BadPageException("Invalid 'page' parameter. It must be a positive integer.");
        }if ( pageSize <= 0)
        {
            throw new BadPageException("Invalid 'pageSize' parameter. It must be a positive integer.");
        }
        
        return await _repository.GetPagingInfo(page, pageSize);
    } 
}


