using WebApplication1.Data;

namespace WebApplication1.Repositories;

public class BaseRepository
{
  
    protected IUnitOfWork _unitOfWork;


    public BaseRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}