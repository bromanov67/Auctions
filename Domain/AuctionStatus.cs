﻿namespace Domain
{
    public enum AuctionStatus
    {
        Unknown = 0,
        Creation = 1,
        WaitBidding = 2,
        Bidding = 3,
        Complete = 4,
        Canceled = 5
    }
}
