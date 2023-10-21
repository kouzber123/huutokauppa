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
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

        public List<Auctioneer> Auctioneers { get; set; } = new List<Auctioneer>();

        public List<Product> BuyHistory { get; set; } = new List<Product>();

    }
}
