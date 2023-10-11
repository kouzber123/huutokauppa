using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }

        public List<AuctionBidder> AuctionBidders { get; set; }

        public List<Auctioneer> Auctioneers { get; set; }

    }
}
