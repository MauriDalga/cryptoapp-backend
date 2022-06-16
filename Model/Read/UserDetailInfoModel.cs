using Domain;

namespace Model.Read;

public class UserDetailInfoModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string WalletAddress { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;

    public List<CoinAccountDetailInfoModel> CoinAccounts { get; set; } = new List<CoinAccountDetailInfoModel>();

    public UserDetailInfoModel(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Lastname = user.Lastname;
        Email = user.Email;
        Token = user.Token;
        WalletAddress = user.WalletAddress;
        Image = user.Image;
        CoinAccounts = user.CoinAccounts != null
            ? user.CoinAccounts.Select(ca => new CoinAccountDetailInfoModel(ca)).ToList()
            : new List<CoinAccountDetailInfoModel>();
    }

    public UserDetailInfoModel()
    {
    }

    public override bool Equals(object? obj)
    {
        var result = false;

        if (obj is UserDetailInfoModel user)
        {
            result = Id == user.Id &&
                     Name.Equals(user.Name) &&
                     Lastname.Equals(user.Lastname) &&
                     Email.Equals(user.Email);
        }

        return result;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}