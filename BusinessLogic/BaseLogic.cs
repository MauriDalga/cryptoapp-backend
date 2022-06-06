using DataAccessInterface;

namespace BusinessLogic;

public abstract class BaseLogic
{
    protected BaseLogic(IUnitOfWork unitOfWork)
    {
    }
}