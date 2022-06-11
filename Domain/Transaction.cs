namespace Domain;

public class Transaction
{
	public int Id { get; set; }
	public decimal Amount { get; set; }
	public int SenderId { get; set; }
	public int ReceiverId { get; set; }

	public int CoinId { get; set; }
	public virtual Coin Coin { get; set; }
}
