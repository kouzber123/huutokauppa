using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.Models;

namespace Api.Data.DTO
{
    public class AuctionProductDto
    {
        //Product
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }


        //Auction
        public int AuctioneerId { get; set; }
        public string Region { get; set; }
        public string AuctionDetails { get; set; }
        public DateTime AuctionStartDate { get; set; }
        public string FormattedAuctionStartDate { get; set; }
        public bool AuctionActive { get; set; } = false;
        public string Category { get; set; }
    }
}
