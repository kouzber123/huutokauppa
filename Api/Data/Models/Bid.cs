using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public decimal BidAmount { get; set; }
    }
}
