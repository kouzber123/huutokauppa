using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.Models;

namespace Api.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public bool IsProductOwner { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;


    }
}
