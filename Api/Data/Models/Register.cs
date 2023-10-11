using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huutokauppa.Data.Models
{
    public class Register
    {
        public string Fname { get; set; }
        public string Lname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
