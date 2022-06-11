namespace Model.Write
{
    public class TransactionModel
    {
        public decimal Amount { get; set; }
        public int CoinId { get; set; }
        public int SenderId { get; set; }
        public string ReceiverWalletAddress { get; set; } = string.Empty;
    }
}
