using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;

namespace huutokauppa.Data.Models
{
    public class Auction
    {
        public int Id { get; set; }

        public int AuctioneerId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Region { get; set; }
        public string AuctionDetails { get; set; }
        //all bids
        public List<Bid> Bids { get; set; } = new List<Bid>();
        public DateTime AuctionStartDate { get; set; }
        public string FormattedAuctionStartDate { get; set; }

        public List<Participate> Participates { get; set; } = new List<Participate>();
        public List<Message> Messages { get; set; } = new List<Message>();
        public bool AuctionActive { get; set; } = false;
        public string Category { get; set; }
        public string HostName { get; set; }

    }
}
