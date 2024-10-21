namespace Database
{
    public class AuctionEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public AuctionStatusEntity? Status { get; set; }

        public bool IsCreation { get; set; }

        public bool IsCanceled { get; set; }

        public UserEntity? UserEntity { get; set; }

        public string Name {  get; set; } = string.Empty;

        public List<LotEntity>? Lots { get; set; } = [];

        public DateTime DateStart { get; set; } 

        public DateTime DateEnd { get; set; }
    }
}
