using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGPeshawarAPI.Models
{
    public class User
    {
       
        public class UserDTO
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int Role { get; set; }
            public int CreatedbyUserId { get; set; }

        }
        public class LoginModel
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

    }
}