using JWTTokenTest.Models;
using JWTTokenTest.Service;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTTokenTest.Controllers
{
    public class TokenService : ITokenservice
    {
        public TokenService()
        {

        }
        public bool ValidUser(LoginViewModel loginUser)
        {
            var result = loginUser.Username == "admin";

            return result;
         
        }
    }
}
