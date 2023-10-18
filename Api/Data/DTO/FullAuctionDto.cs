using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.DTO;

namespace Api.Data.DTO
{
    public class FullAuctionDto
    {
        public int AuctioneerId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public string Region { get; set; }
        public string AuctionDetails { get; set; }
        public DateTime AuctionStartDate { get; set; }
        public string FormattedAuctionStartDate { get; set; }
        public bool AuctionActive { get; set; } = false;
        public string Category { get; set; }
        public string HostName { get; set; }
        public List<AuctionParticipantDto> AuctionParticipants { get; set; } = new List<AuctionParticipantDto>();
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>();

        public List<BidDto> Bids { get; set; } = new List<BidDto>();
        public void AddBid(BidDto bid, AuctionParticipantDto auctionParticipant)
        {
            Bids.Add(bid);
            AuctionParticipants.Add(auctionParticipant);
        }
    }
}
