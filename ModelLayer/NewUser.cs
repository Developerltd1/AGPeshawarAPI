using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class NewUser
    {
        public partial class AddUser
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            public string UserPassword { get; set; }
            [Required]
            public int RoleId { get; set; }
            public int CreatedBy { get; set; }

            public List<Roles> roleLst { get; set; }

            public AddUser()
            {
                roleLst = new List<Roles>();
            }
        }
        public partial class AddUserResponse
        {
            public string Message { get; set; }
            public bool IsSaved { get; set; }

        }
        public partial class EditUser
        {
            [Required]
            public int UserId { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public string UserPassword { get; set; }
            [Required]
            public int RoleId { get; set; }
            public int CreatedBy { get; set; }
        }

        public partial class GetUserRecord
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserPassword { get; set; }
            public int RoleId { get; set; }
            public string Role { get; set; }

        }

    }
}
