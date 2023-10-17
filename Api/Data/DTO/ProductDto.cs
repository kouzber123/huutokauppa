using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using huutokauppa.Data.Models;

namespace huutokauppa.Data.DTO
{
    public class ProductDto
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
