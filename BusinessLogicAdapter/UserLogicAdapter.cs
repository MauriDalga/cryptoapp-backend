using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic;
using BusinessLogicValidatorInterface;
using Domain;
using Model.Read;
using Model.Write;

namespace BusinessLogicAdapter;
public class UserLogicAdapter : BaseLogicAdapter
{
    private readonly UserLogic _userLogic;
    private readonly IBusinessValidator<UserModel> _userModelValidator;

    public UserLogicAdapter(
        UserLogic userLogic, 
        IBusinessValidator<UserModel> userModelValidator,
        IMapper mapper) : base (mapper)
    {
        _userLogic = userLogic;
        _userModelValidator = userModelValidator;
    }

    public UserDetailInfoModel Create(UserModel user)
    {
        _userModelValidator.CreationValidation(user);

        var userEntity = _mapper.Map<User>(user);

        var userCreated = _userLogic.Add(userEntity);

        return _mapper.Map<UserDetailInfoModel>(userCreated);
    }

    public void Delete(int id)
    {
        _userModelValidator.ValidateIdentifier(id);

        _userLogic.Delete(id);
    }

    public void Edit(int id, UserModel user)
    {
        _userModelValidator.ValidateIdentifier(id);
        _userModelValidator.EditionValidation(id, user);

        var userEntity = _mapper.Map<User>(user);

        userEntity.Id = id;

        _userLogic.Edit(id, userEntity);
    }

    public IEnumerable<UserBasicModel> GetCollection()
    {
        var users = _userLogic.GetCollection();

        return _mapper.Map<IEnumerable<UserBasicModel>>(users);
    }

    public UserDetailInfoModel Get(int id)
    {
        _userModelValidator.ValidateIdentifier(id);

        var user = _userLogic.Get(id);

        return _mapper.Map<UserDetailInfoModel>(user);
    }
}