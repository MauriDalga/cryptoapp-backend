namespace Domain;

public class CoinAccount
{
    public int CoinId { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
    public Coin? Coin { get; set; }
}