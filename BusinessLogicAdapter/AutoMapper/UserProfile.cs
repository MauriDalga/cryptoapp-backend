using AutoMapper;
using Domain;
using Model.Read;
using Model.Write;

// https://docs.automapper.org/en/stable/
namespace BusinessLogicAdapter.AutoMapper;
public class UserProfile : Profile
{
    public UserProfile()
    {
        FromUserModelToUser();
        FromUserEditModelToUser();
        FromUserToUserBasicModel();
        FromUserToUserDetailInfoModel();
    }

    private void FromUserModelToUser()
    {
        CreateMap<UserModel, User>();
    }

    private void FromUserEditModelToUser()
    {
        CreateMap<UserEditModel, User>();
    }

    private void FromUserToUserBasicModel()
    {
        CreateMap<User, UserBasicModel>();
    }

    private void FromUserToUserDetailInfoModel()
    {
        CreateMap<User, UserDetailInfoModel>();
    }
}