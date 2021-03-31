using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamInternationalTestEf.Models;

namespace TeamInternationalTestWebApi.Models
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }

        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Username = user.Username;
            Token = token;
        }
    }
}
