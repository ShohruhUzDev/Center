using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos
{
   public class LoginDto
    {
        public string  Email { get; set; }
        public string  Password { get; set; }
    }
    
    
    
    
    public class UserDto:LoginDto
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }
    }
}
