using FluentResults;


namespace Database
{
    public class LotEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int AuctionId { get; set; }

        public AuctionEntity? AuctionEntity { get; set; }
        
        public LotStatusEntity? Status { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal MinPrice { get; set; }

        public List<BetEntity> Bets { get; set; } = [];

        public decimal? RansomPrice { get;  set; }

        public List<string> Images { get; set; } = [];

    }
}
