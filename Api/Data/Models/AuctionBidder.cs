using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.Models
{
    public class AuctionBidder
    {
        //user > one bidder > per auction but can

        public int Id { get; set; }

        public List <User> User { get; set; }

        public List<Bid> MyBids { get; set; } = new List<Bid>();
        public List<Auction> Auctions { get; set; } = new List<Auction>();

        //personal bids
        public void AddBid(Bid bid)
        {
            MyBids.Add(bid);
        }
        public void AddAuction(Auction auction)
        {
            Auctions.Add(auction);
        }

    }
}
