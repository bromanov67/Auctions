namespace Database
{
    public class BetEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public UserEntity? UserEntity { get; set; }

        public Guid LotId { get; set;}

        public LotEntity? LotEntity { get; set; }

        public decimal Amount { get; set; }    

        public DateTime DateTime { get; set; }
    }
}
