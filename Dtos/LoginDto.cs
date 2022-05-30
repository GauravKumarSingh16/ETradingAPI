using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETradingAPI.Dtos
{
    public class LoginDto
    { 
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
