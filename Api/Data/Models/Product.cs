using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;

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
        public string Description { get; set; }
        public int Quantity { get; set; }

        public List<Photo> Photos { get; set; } = new List<Photo>();
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
