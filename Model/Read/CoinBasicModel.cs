using Domain;

namespace Model.Read;

public class CoinBasicModel
{
	public int Id { get; set; }
	public string LongName { get; set; } = string.Empty;
	public string ShortName { get; set; } = string.Empty;
	public string Icon { get; set; } = string.Empty;

	public CoinBasicModel(Coin coin)
	{
		Id = coin.Id;
		LongName = coin.LongName;
		ShortName = coin.ShortName;
		Icon = coin.Icon;
	}

    public override bool Equals(object? obj)
    {
        var result = false;

        if (obj is CoinBasicModel coin)
        {
            result = Id == coin.Id &&
                LongName.Equals(coin.LongName) &&
                ShortName.Equals(coin.ShortName);
        }

        return result;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

