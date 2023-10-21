using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.Models;

namespace Api.Data.Models
{
    public class Participate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
        public List<Bid> Bids { get; set; } = new List<Bid>();
    }
}
