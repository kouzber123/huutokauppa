using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;

namespace huutokauppa.Data.DTO
{
    public class ProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int OwnerId { get; set; }


        public string OwnerName { get; set; }
    }
}
