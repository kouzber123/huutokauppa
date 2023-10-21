using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.DTO
{
    public class AuctioneerDto
    {
            public int Id { get; set; }

        public List<UserDto> User { get; set; } = new List<UserDto>();

        // Represents a list of auctions initiated by this auctioneer
        public List<AuctionDto> Auctions { get; set; } = new List<AuctionDto>();

        public void AddAuction(AuctionDto auction)
        {

            Auctions.Add(auction);
        }
    }
}
