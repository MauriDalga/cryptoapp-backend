using AutoMapper;
using Domain;
using Model.Read;

namespace BusinessLogicAdapter.AutoMapper;

public class CoinAccountProfile : Profile
{
    public CoinAccountProfile()
    {
        FromCoinAccountToCoinAccountModel();
    }

    private void FromCoinAccountToCoinAccountModel()
    {
        CreateMap<CoinAccount, CoinAccountDetailInfoModel>()
            .ConstructUsing(account => new CoinAccountDetailInfoModel(account));
    }
}