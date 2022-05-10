using DataAccessInterface;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _efCoreContext;

    public UnitOfWork(DbContext context)
    {
        _efCoreContext = context;
    }

    public IRepository<T> GetRepository<T>() where T : class
    {
        var efCoreRepository = new EfCoreRepository<T>(_efCoreContext);

        return efCoreRepository;
    }
}