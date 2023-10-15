using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.DTO
{
    public class MessageDto
    {
        // public int Id { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        // public string FormattedTimeStamp { get; set; }

    }
}
