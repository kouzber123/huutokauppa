using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace huutokauppa.Data.DTO
{
    public class CreateProductDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int OwnerId { get; set; }

        // [JsonIgnore]
        // public string OwnerName { get; set; }
    }
}
