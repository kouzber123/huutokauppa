using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.DTO;

namespace Api.Data.DTO
{
    public class FullAuctionDto
    {
        public int Id { get; set; }
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
        public List<ParticipateAuctionDto> ParticipateAuctions { get; set; } = new List<ParticipateAuctionDto>();
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>();

        public List<BidDto> Bids { get; set; } = new List<BidDto>();
    }
}
