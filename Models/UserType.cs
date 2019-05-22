using System;
using System.Collections.Generic;

namespace GymApp.Models
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<User> User { get; set; }
    }
}
