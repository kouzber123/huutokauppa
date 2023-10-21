using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.DTO;

namespace Api.Data.DTO
{
    public class ParticipateAuctionDto
    {
         public int Id { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public int AuctionId { get; set; }
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>();
        public List<BidDto> Bids { get; set; } = new List<BidDto>();
    }
}
