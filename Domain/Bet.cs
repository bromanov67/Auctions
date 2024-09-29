namespace Domain
{
    public class Bet
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid LotId { get; set;}

        public decimal Amount { get; set; }    

        public DateTime DateTime { get; set; }
    }
}
