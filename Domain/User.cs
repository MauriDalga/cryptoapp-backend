namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string WalletAddress { get; set; } = Guid.NewGuid().ToString("N");
        public string Token { get; set; } = Guid.NewGuid().ToString();
        public string DeviceToken { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public virtual List<CoinAccount> CoinAccounts { get; set; } = new List<CoinAccount>();
        public virtual List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
