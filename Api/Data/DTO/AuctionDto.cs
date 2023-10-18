using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.Models;

namespace huutokauppa.Data.DTO
{
    public class AuctionDto
    {
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
    }
}
