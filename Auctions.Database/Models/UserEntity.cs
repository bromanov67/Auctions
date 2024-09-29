namespace Database
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<LotEntity> Lots { get; set; } = [];

        public List<AuctionEntity>? Auctions { get; set; }

        public List<BetEntity> Bets { get; set; } = [];
    }
}
