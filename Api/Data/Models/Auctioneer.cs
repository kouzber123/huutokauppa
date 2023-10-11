using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.Models
{
    public class Auctioneer
    {
        //everyu auction can have one item and owner but multiple bidders
        public int Id { get; set; }

        public List<User> User { get; set; }

        // Represents a list of auctions initiated by this auctioneer
        public List<Auction> Auctions { get; set; } = new List<Auction>();

        public void AddAuction(Auction auction)
        {

            Auctions.Add(auction);
        }

    }
}
