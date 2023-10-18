using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.DTO
{
    public class AuctionBidderDto
    {
        public int Id { get; set; }

        public List<UserDto> User { get; set; }

        public List<BidDto> MyBids { get; set; } = new List<BidDto>();


        //personal bids
        public void AddBid(BidDto bid)
        {
            MyBids.Add(bid);
        }
    
    }
}
