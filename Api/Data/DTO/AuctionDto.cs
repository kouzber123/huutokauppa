using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.DTO
{
    public class AuctionDto
    {
        public int Id { get; set; }

        public int AuctioneerId { get; set; }
        public AuctioneerDto Auctioneer { get; set; }


        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        //all bids
        public List<BidDto> Bids { get; set; } = new List<BidDto>();
        public List<AuctionBidderDto> AuctionBidders { get; set; } = new List<AuctionBidderDto>();


        public void AddBid(BidDto bid, AuctionBidderDto auctionBidder)
        {
            Bids.Add(bid);
            AuctionBidders.Add(auctionBidder);
        }
    }
}
