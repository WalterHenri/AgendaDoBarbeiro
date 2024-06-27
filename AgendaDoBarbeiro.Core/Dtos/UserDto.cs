using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDoBarbeiro.Core.Dtos
{
    public class UserDto
    {
        public required string Phone { get; set; }  //Unique Telephone Number
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
