using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;
public class UserLogic : BaseLogic
{
    private readonly IRepository<User> _userRepository;
    private readonly IBusinessValidator<User> _userValidator;

    public UserLogic(
        IBusinessValidator<User> userValidator, 
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _userRepository = unitOfWork.GetRepository<User>();
        _userValidator = userValidator;
    }

    public User Add(User user)
    {
        _userValidator.CreationValidation(user);

        _userRepository.InsertAndSave(user);

        return user;
    }

    public void Delete(int id)
    {
        _userValidator.ValidateIdentifier(id);
        _userRepository.DeleteByIdAndSave(id);
    }

    public void Edit(int id, User user)
    {
        _userValidator.ValidateIdentifier(id);
        _userValidator.EditionValidation(id, user);

        _userRepository.UpdateAndSave(user);
    }

    public IEnumerable<User> GetCollection()
    {
        return _userRepository.GetCollection();
    }

    public User Get(int id)
    {
        _userValidator.ValidateIdentifier(id);

        return _userRepository.Get(users => users.Id == id);
    }
}