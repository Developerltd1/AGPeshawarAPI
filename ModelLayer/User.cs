using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelLayer
{
    public class User
    {
       
        public class UserDTO
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserPassword { get; set; }
            public int RoleId { get; set; }
            public int CreatedbyUserId { get; set; }

        }
        public partial class LoginModel
        {
            public class RequestTest
            {
                public string UserName { get; set; }
                public string Password { get; set; }
            }
            public  class Request
            {
                public int UserId { get; set; }
                public string UserName { get; set; }
                public string Password { get; set; }
            }
            public  class Response
            {
                public string UserName { get; set; }
                public int UserId { get; set; }
                public int Role_Id { get; set; }

                public string LoginStatus { get; set; }
                public UserData userData { get; set; }
            }
            public class UserData
            {
                public string UserName { get; set; }
                public int UserId { get; set; }
                public int Role_Id { get; set; }
            }

        }

    }
}