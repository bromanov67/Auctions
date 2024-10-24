﻿using FluentResults;
using System;


namespace Domain
{
    public class Lot
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public LotStatus Status { get; set; }

        public string Description { get; set; } = string.Empty;

        public IReadOnlyCollection<string> Images { get; set; } = new List<string>();

        public decimal MinPrice { get; set; }

        public decimal BetStep { get; set; }

        public decimal? RansomPrice { get; set; }

        public IReadOnlyCollection<Bet> Bets => _bets;

        private List<Bet> _bets = new List<Bet>();

        public Lot() { }

        public Lot(string name, int auctionId, string description, decimal minPrice, decimal betstep, decimal? ransomPrice, params string[] images)
        {
            Name = name;
            AuctionId = auctionId;
            Description = description;
            Images = images;
            MinPrice = minPrice;
            BetStep = betstep;
            RansomPrice = ransomPrice;
        }

          public Result TryDoBet(Bet bet)
        {
            if (Status != LotStatus.Bidding)
                return Result.Fail("Торги завершены");

            if (Bets.Any(b => b.Amount >= bet.Amount))
                return Result.Fail("Ваша ставка перекрыта");

            _bets.Add(bet);
            return Result.Ok();
        }
    }
}
