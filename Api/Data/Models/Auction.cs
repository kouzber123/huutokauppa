using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.Models
{
    public class Auction
    {
        public int Id { get; set; }

        public int AuctioneerId { get; set; }
        public Auctioneer Auctioneer { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }

        //all bids
        public List<Bid> Bids { get; set; } = new List<Bid>();
        public List<AuctionBidder> AuctionBidders { get; set; } = new List<AuctionBidder>();


        public void AddBid(Bid bid, AuctionBidder auctionBidder)
        {
            Bids.Add(bid);
            AuctionBidders.Add(auctionBidder);
        }
    }
}
