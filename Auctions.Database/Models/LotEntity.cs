using FluentResults;


namespace Database
{
    public class LotEntity
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public AuctionEntity? AuctionEntity { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public LotStatusEntity? Status { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<string> Images { get; set; } = [];

        public List<BetEntity> Bets { get; set; } = [];

    }
}
