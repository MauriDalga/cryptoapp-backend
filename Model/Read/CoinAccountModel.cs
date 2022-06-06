using Domain;

namespace Model.Read;

public class CoinAccountModel
{
    public string LongName { get; set; }
    public string ShortName { get; set; }
    public string Icon { get; set; }
    public decimal Balance { get; set; }

    public CoinAccountModel(CoinAccount coinAccount)
    {
        LongName = coinAccount.Coin!.LongName;
        ShortName = coinAccount.Coin.ShortName;
        Icon = coinAccount.Coin.Icon;
        Balance = coinAccount.Balance;
    }
    
    public CoinAccountModel()
    {
    }
}