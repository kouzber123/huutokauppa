using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.Models
{
    /// <summary>
    /// every product has owner id
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }


    }
}
