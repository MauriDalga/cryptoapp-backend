namespace Domain;

public class CoinAccount
{
    public int Id { get; set; }
    public decimal Balance { get; set; }

    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public int CoinId { get; set; }
    public virtual Coin? Coin { get; set; }
}
