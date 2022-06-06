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
        CreateMap<CoinAccount, CoinAccountModel>().ConstructUsing(account => new CoinAccountModel(account));
    }
}