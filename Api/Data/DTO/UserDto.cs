using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.DTO
{
    public class UserDto
    {

        public string Fname { get; set; }
        public string Lname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }

        public List<AuctionBidderDto> AuctionBidders { get; set; }

        public List<AuctioneerDto> Auctioneers { get; set; }
    }
}
