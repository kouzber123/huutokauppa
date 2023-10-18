using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.DTO
{
    public class BidDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string User { get; set; }
        public decimal BidAmount { get; set; }
    }
}
