using Domain;

namespace Model.Read;

public class CoinAccountDetailInfoModel
{
    public int Id { get; set; }
    public CoinBasicModel Coin { get; set; }
    public decimal Balance { get; set; }

    public CoinAccountDetailInfoModel(CoinAccount coinAccount)
    {
        Id = coinAccount.Id;
        Coin = coinAccount.Coin != null
            ? new CoinBasicModel(coinAccount.Coin)
            : new CoinBasicModel(new Coin());
        Balance = coinAccount.Balance;
    }
}

