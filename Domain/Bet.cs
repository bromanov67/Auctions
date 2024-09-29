namespace Domain
{
    public class Bet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int LotId { get; set;}

        public decimal Amount { get; set; }    

        public DateTime DateTime { get; set; }
    }
}
