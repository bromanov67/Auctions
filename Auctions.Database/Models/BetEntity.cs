namespace Database
{
    public class BetEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserEntity? UserEntity { get; set; }

        public int LotId { get; set;}

        public LotEntity? LotEntity { get; set; }

        public decimal Amount { get; set; }    

        public DateTime DateTime { get; set; }
    }
}
