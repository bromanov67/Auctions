using System.Net.Sockets;

namespace Domain
{
    public class Auction
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name {  get; set; }

        public Dictionary<int, Lot> Lots { get; set; } = [];

        public bool IsCreation { get; set; }

        public bool IsCanceled { get; set; }

        public DateTime DateStart { get; set; } 

        public DateTime DateEnd { get; set; }

        /*public Auction(string name, DateTime dateStart, DateTime dateEnd)
        {
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            IsCreation = true;
        }*/

       /* public DateTime DateEnd
        {
            get
            {
                var maxBetDate = Lots.Values.SelectMany(l => l.Bets).Max(s => s.DateTime).AddSeconds(30);

                return _dateEnd > maxBetDate ? _dateEnd : maxBetDate;
            }
            init => _dateEnd = value;
            
        }*/
        public AuctionStatus Status
        {
            get
            {
                var dateTimeNow = DateTime.UtcNow;

                if (IsCreation)
                    return AuctionStatus.Creation;

                if (dateTimeNow < DateStart)
                    return AuctionStatus.WaitBidding;     

                if (dateTimeNow > DateStart && dateTimeNow < DateEnd)
                    return AuctionStatus.Bidding;

                if (dateTimeNow > DateEnd)
                    return AuctionStatus.Complete;
                else
                    return AuctionStatus.Canceled;

            }
        }
        public Auction() { }
        public Auction(string name, Guid userId, DateTime dateStart, DateTime dateEnd)
        {
            Name = name;
            UserId = userId;
            DateStart = dateStart;
            DateEnd = dateEnd;
            IsCreation = true;
            Id = Guid.NewGuid();
        }

    }
}
