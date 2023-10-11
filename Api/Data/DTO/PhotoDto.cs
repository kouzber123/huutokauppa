using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.DTO
{
    public class PhotoDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
