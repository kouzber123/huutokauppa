using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int ReferenceId{ get; set; }

    }
}
