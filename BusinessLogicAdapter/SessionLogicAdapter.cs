using AutoMapper;
using BusinessLogic;
using BusinessLogicValidatorInterface;
using Domain;
using Model.Read;
using Model.Write;

namespace BusinessLogicAdapter;

public class SessionLogicAdapter : BaseLogicAdapter
{
	private readonly UserLogic _userLogic;
	private readonly IBusinessValidator<SessionModel> _sessionModelValidator;

    public SessionLogicAdapter(
        UserLogic userLogic,
        IBusinessValidator<SessionModel> sessionModelValidator,
        IMapper mapper) : base(mapper)
    {
        _userLogic = userLogic;
        _sessionModelValidator = sessionModelValidator;
    }

    public UserDetailInfoModel LogIn(SessionModel session)
    {
        _sessionModelValidator.LogInValidation(session);

        var userLogIn = _userLogic
            .GetUserFromLogIn(session.Email, session.Password, session.DeviceToken);

        return _mapper.Map<UserDetailInfoModel>(userLogIn);
    }

    public bool IsValidToken(string token, string? id, string? queryUserId)
    {
        return _userLogic.IsValidToken(token, id, queryUserId);
    }
}

